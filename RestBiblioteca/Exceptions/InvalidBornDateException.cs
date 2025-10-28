using System.Net;

namespace RestBiblioteca.Exceptions;

public class InvalidBornDateException : HttpException
{
    public InvalidBornDateException(string message = "Data de nascimento inválida")
        : base(HttpStatusCode.BadRequest, message) { }
    
    
}