using System.Globalization;

namespace TerritorEx.Api.Helpers;

public class ExceptionHelper : Exception
{
    public ExceptionHelper() { }

    public ExceptionHelper(string message) : base(message) { }

    public ExceptionHelper(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
}