using Microsoft.JSInterop;

namespace FinUnsize.Helpers;

public interface ICookieManager
{
    public Task SetValue(string value, int? days = null);
    public Task<string> GetValue(string def = "");
    public Task DeleteValue();
}

public class CookieManager : ICookieManager
{
    readonly IJSRuntime _jsRuntime;
    private string _storage = "accessToken";
    string expires = "";

    public CookieManager(IJSRuntime JSRuntime)
    {
        _jsRuntime = JSRuntime;
    }

    public async Task SetValue(string value, int? hours = null)
    {
        var curExp = hours != null ? hours > 0 ? Hours(hours.Value) : "" : expires;
        await SetCookie($"{_storage}={value}; expires={curExp}; path=/");
    }

    public async Task<string> GetValue(string def = "")
    {
        var cValue = await GetCookie();
        return ParseCookieValue(cValue, _storage, def);
    }

    private string ParseCookieValue(string cookie, string key, string def)
    {
        if (string.IsNullOrEmpty(cookie))
        {
            return def;
        }

        var vals = cookie.Split(';');
        foreach (var val in vals)
        {
            if (val.Substring(0, val.IndexOf('=')).Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                return val.Substring(val.IndexOf('=') + 1);
            }
        }

        return def;
    }

    public async Task DeleteValue()
    {
        await _jsRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{_storage}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;\"");
    }

    private async Task<string> GetCookie()
    {
        return await _jsRuntime.InvokeAsync<string>("eval", $"document.cookie");
    }

    private async Task SetCookie(string value)
    {
        await _jsRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{value}\"");
    }

    private static string Hours(int hours) => DateTime.Now.AddHours(hours).ToUniversalTime().ToString("R");
}