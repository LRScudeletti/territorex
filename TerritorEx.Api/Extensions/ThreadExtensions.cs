using System.Globalization;

namespace TerritorEx.Api.Extensions;

public static class ThreadExtensions
{
    public static void SetCulture(this Thread thread, string culture)
    {
        if (string.IsNullOrWhiteSpace(culture))
            return;

        SetCulture(thread, new CultureInfo(culture.Trim()));
    }

    private static void SetCulture(this Thread thread, CultureInfo culture)
    {
        if (culture == null)
            return;

        thread.CurrentCulture = culture;
        thread.CurrentUICulture = culture;
    }
}