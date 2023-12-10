using Microsoft.JSInterop;

namespace FinUnsize.Helpers;

public static class LocalStorageHelper
{
    private static IJSRuntime _jsRuntime;
    private static string _signature;

    public static void Initialize(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public static async Task SetLocalAsync(string signature, string body)
    {
        _signature = signature;
        await _jsRuntime.InvokeAsync<string>("localStorage.setItem", _signature, body);
    }

    public static async Task<string> GetLocalAsync()
    {
        if (!string.IsNullOrEmpty(_signature))
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", _signature);
        }
        throw new InvalidOperationException("IJSRuntime não inicializado. Chame o método Initialize antes de usar esta classe.");
    }
}