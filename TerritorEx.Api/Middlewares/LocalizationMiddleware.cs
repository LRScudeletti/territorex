using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace TerritorEx.Api.Middlewares
{
    public static class LocalizationMiddleware
    {
        public static void UseLocalizationMiddleware(this IApplicationBuilder app, IConfiguration configuration)
        {
            var supportedCultures = configuration.GetSection("Globalization:SupportedCultures")
                .Get<List<string>>().Where(x => !string.IsNullOrWhiteSpace(x)).Distinct()
                .Select(x => new CultureInfo(x)).ToList();

            var defaultCulture = configuration["Globalization:DefaultCulture"];

            if (defaultCulture != null)
                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(defaultCulture, defaultCulture),

                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                });
        }
    }
}
