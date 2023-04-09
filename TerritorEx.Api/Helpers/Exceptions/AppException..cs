using System.Globalization;

// ReSharper disable UnusedMember.Global
namespace TerritorEx.Api.Helpers.Exceptions;

public abstract class AppException : Exception
{
    protected AppException() { }

    protected AppException(string message) : base(message) { }

    protected AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
}