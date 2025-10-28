using System.Net;
using Moq;
using Moq.Protected;
using RestBiblioteca.Exceptions;
using RestBiblioteca.service.impl;

namespace RestBibliotecaTestes.Service;

public class ViaCepAdapterTests
{
    [Fact]
    public async Task ShouldThrowInvalidCepExceptionWhenCepApiReturns400()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            });

        var httpClient = new HttpClient(handlerMock.Object);
        var adapter = new ViaCepAdapter(httpClient);
        
        await Assert.ThrowsAnyAsync<InvalidCepException>(() => adapter.findAdressAsync("00000000"));
    }
}