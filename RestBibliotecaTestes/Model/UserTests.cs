using RestBiblioteca.model;

namespace RestBibliotecaTestes.Model;

public sealed class UserTests
{
    [Fact]
    
    public void ShouldCreateNewUser()
    {
        var expectedId = new Random().NextInt64();
        var expectedEmail = "yansilva303@gmail.com";
        var expectedUsername = "yansilva303";
        var expectedPassword = "123456";
        var expectedRole = Role.User;
        var expectedBithDate = new DateTime(1999, 12, 12);
        var expectedCep = "40727800";
        var expectedStreet = "Rua das Flores";
        var expectedNeighborhood = "Centro";
        var expectedCity = "Salvador";
        var expectedUf = State.BA;
        var expectedState = State.BA;
        var expectedRegion = "BA";
        var expectedDdd = 71;
        var expectedAdress = new Adress(expectedCep,
            expectedStreet,
            expectedNeighborhood,
            expectedCity,
            expectedUf,
            expectedState,
            expectedRegion,
            expectedDdd);

        var expectedUser = new User(expectedId,
            expectedEmail,
            expectedUsername,
            expectedPassword,
            expectedRole,
            expectedBithDate,
            expectedAdress);

       Assert.Equal(expectedId, expectedUser.Id);
       Assert.Equal(expectedEmail, expectedUser.Email);
       Assert.Equal(expectedUsername, expectedUser.Username);
       Assert.Equal(expectedPassword, expectedUser.Password);
       Assert.Equal(expectedRole, expectedUser.Role);
       Assert.Equal(expectedBithDate, expectedUser.BirthDate);
       Assert.Equal(expectedCep, expectedUser.GetCep());
       Assert.Equal(expectedStreet, expectedUser.GetStreet());
       Assert.Equal(expectedNeighborhood, expectedUser.GetNeighborhood());
       Assert.Equal(expectedCity, expectedUser.GetCity());
       Assert.Equal(expectedUf, expectedUser.GetUf());
       Assert.Equal(expectedState, expectedUser.GetState());
       Assert.Equal(expectedRegion, expectedUser.GetRegion());
       Assert.Equal(expectedDdd, expectedUser.GetDdd());
       Assert.Equal(expectedAdress, expectedUser.Adress);
    }
}