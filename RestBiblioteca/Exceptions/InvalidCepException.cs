using System.Net;

namespace RestBiblioteca.Exceptions;

public class InvalidCepException : HttpException
{
    public InvalidCepException(string message = "Cep inválido")
        : base(HttpStatusCode.BadRequest, message) { }
}