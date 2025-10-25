namespace RestBiblioteca.Exceptions;

public class InvalidCepException : Exception
{
    public InvalidCepException(string message)
        : base(message) { }
}