using System.Diagnostics.CodeAnalysis;

namespace RestBiblioteca.model;

internal class User
{
    public long Id {get; private set;}
    public string Email {get; private set;}
    public string Username {get; private set;}
    public string Password {get; private set;}
    public Role Role {get; private set;}
    public DateTime BirthDate {get; private set;}
    public Adress Adress {get; private set;}

    private readonly List<Loan> _loans = new ();
    
    public IReadOnlyCollection<Loan> Loans => _loans;

    public User(){}

    public User(long id, string email, string username, string password, Role role, DateTime birthDate, Adress adress)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
        Role = role;
        BirthDate = birthDate;
        Adress = adress;
    }
    public User(string email, string username, string password, Role role, DateTime birthDate, Adress adress)
    {
        Email = email;
        Username = username;
        Password = password;
        Role = role;
        BirthDate = birthDate;
        Adress = adress;
    }

    public User Update(User newUser)
    {
        Email = newUser.Email;
        Username = newUser.Username;
        Password = newUser.Password;
        BirthDate = newUser.BirthDate;
        Adress = newUser.Adress;
        return this;
    }

    public string GetCep()
    {
        return Adress.Cep;
    }

    public string GetStreet()
    {
        return Adress.Street;
    }

    public string GetNeighborhood()
    {

        return Adress.Neighborhood;
    }

    public string GetCity()
    {
        return Adress.City;
    }

    public State GetUf()
    {
        return Adress.Uf;
    }

    public State GetState()
    {
        return Adress.State;
    }

    public string GetRegion()
    {
        return Adress.Region;
    }

    public int GetDdd()
    {
        return Adress.Ddd;
    }
}