using System.Net;

namespace RestBiblioteca.Exceptions;

public class BookDontExistExcpetion : HttpException
{
    public BookDontExistExcpetion(string message = "Esse livro não existe ou não foi cadastrado") 
        : base(HttpStatusCode.NotFound, message)
    {
        
    }
}