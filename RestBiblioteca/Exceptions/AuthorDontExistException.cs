using System.Net;

namespace RestBiblioteca.Exceptions;

public class AuthorDontExistException : HttpException
{
    public AuthorDontExistException(string message = "Esse autor não existe ou não foi cadastrado")
        : base(HttpStatusCode.NotFound, message) { }

}