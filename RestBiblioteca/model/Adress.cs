namespace RestBiblioteca.model;

public class Adress
{
    public string Cep {get; private set;}
    public string Street {get; private set;}
    public string Neighborhood {get; private set;}
    public string City {get; private set;}
    public State Uf {get; private set;}
    public State State {get; private set;}
    public string Region {get; private set;}
    public int Ddd {get; private set;}

    public Adress(string cep, string street, string neighborhood, string city, State uf, State state, string region, int ddd)
    {
        Cep = cep;
        Street = street;
        Neighborhood = neighborhood;
        City = city;
        Uf = uf;
        State = state;
        Region = region;
        Ddd = ddd;
    }
}