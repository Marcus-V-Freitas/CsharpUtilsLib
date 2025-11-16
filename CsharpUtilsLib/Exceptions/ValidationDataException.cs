namespace CsharpUtilsLib.Exceptions;

public sealed class ValidationDataException(string? message) : Exception(message)
{
}