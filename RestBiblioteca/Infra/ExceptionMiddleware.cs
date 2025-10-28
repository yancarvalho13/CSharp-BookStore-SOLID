using Microsoft.AspNetCore.Diagnostics;
using RestBiblioteca.Exceptions;

namespace RestBiblioteca.infra;

public class ExceptionMiddleware : IExceptionHandler
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception ,"Erro não tratado");
        var status = exception is HttpException hs ? hs.StatusCode : StatusCodes.Status500InternalServerError;
        var message = exception is HttpException hm ? hm.Message : exception.Message;
        var payload = exception is HttpException hp ? hp.Payload : null;
        
        httpContext.Response.StatusCode = status;
        httpContext.Response.ContentType = "application/json";

        var body = new { erro = message, details = payload };
        await httpContext.Response.WriteAsJsonAsync(body);
        return true;
    }
}