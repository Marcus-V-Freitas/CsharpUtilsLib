namespace CsharpUtilsLib.Exceptions;

public sealed class ValidationDataException : Exception
{
    public ValidationDataException(string? message) : base(message)
    {
    }
}