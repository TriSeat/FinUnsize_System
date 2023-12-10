using FinUnsize.Response;
using Microsoft.AspNetCore.Components;

namespace FinUnsize.Helpers;
public class Authentication
{

    private readonly ApiResponse _apiResponse;
    private readonly NavigationManager _navigationManager;

    public Authentication(ApiResponse apiResponse, NavigationManager navigationManager)
    {
        _apiResponse = apiResponse;
        _navigationManager = navigationManager;
    }

    public async Task Access(string role)
    {
        await _apiResponse.AuthorizationHeader();
        var credentials = await _apiResponse.Credentials();
        bool isAuthorized = role == credentials?.role;
        if (!isAuthorized)
        {
            _navigationManager.NavigateTo("/user/login");
        }
    }
}