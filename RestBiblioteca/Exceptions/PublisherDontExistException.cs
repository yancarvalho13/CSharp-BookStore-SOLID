using System.Net;

namespace RestBiblioteca.Exceptions;

public class PublisherDontExistException : HttpException
{
    public PublisherDontExistException(string message = "Editora não existe ou não foi cadastrada")
        : base(HttpStatusCode.BadRequest, message) { }

}