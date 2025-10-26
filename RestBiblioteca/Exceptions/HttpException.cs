using System.Net;

namespace RestBiblioteca.Exceptions;

public class HttpException : Exception
{
    public int StatusCode {get;}
    public object? Payload {get;}
    
    public HttpException(HttpStatusCode statusCode, string message, object? payload = null) : base(message)
    {
        StatusCode = (int)statusCode;
        Payload = payload;
    }
    
    
}