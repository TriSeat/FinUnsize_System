using FinUnsize.Response;
using MatBlazor;
namespace FinUnsize.Helpers;

public static class ServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ApiResponse>();
        services.AddScoped<ICookieManager, CookieManager>();
        services.AddScoped<Authentication>();
        services.AddScoped<ApiService>();
        services.AddMatBlazor();

        return services;
    }
}