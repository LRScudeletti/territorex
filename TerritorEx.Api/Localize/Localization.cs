using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace TerritorEx.Api.Localize;

public static class Localization
{
    public static void AddLocalization(IServiceCollection services)
    {
        services.AddLocalization(x =>
        {
            x.ResourcesPath = @"Localize\Resources";
        });

        services.Configure<RequestLocalizationOptions>(x =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR")
            };

            x.SupportedCultures = supportedCultures;
            x.SupportedUICultures = supportedCultures;

            x.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
            {
                var languages = context.Request.Headers["Accept-Language"].ToString();
                var currentLanguage = languages.Split(',').FirstOrDefault();
                var defaultLanguage = string.IsNullOrEmpty(currentLanguage) ? "en-US" : currentLanguage;

                var language = defaultLanguage;
                if (!supportedCultures.Any(s => s.Name.Equals(language)))
                    defaultLanguage = "en-US";

                return Task.FromResult(new ProviderCultureResult(defaultLanguage, defaultLanguage));
            }));
        });
    }
}