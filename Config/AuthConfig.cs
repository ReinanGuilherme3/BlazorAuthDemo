using BlazorAuthDemo.Policies;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BlazorAuthDemo.Config;

public static class AuthConfig
{
    public static void AddAuthConfig(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        services.AddAuthorization(config =>
        {
            foreach (var userPolicy in AuthPolicy.GetPolicies())
                config.AddPolicy(userPolicy, cfg => cfg.RequireClaim(userPolicy, "true"));
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "auth_token";
                options.LoginPath = "/login";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                options.LogoutPath = "/logout";
                options.AccessDeniedPath = "/access-denied";
            });

        services.AddCascadingAuthenticationState();
    }
}
