namespace RestBiblioteca.model;

public class Publisher
{
    public long Id {get; private set; }
    public string Name { get; private set; } = default!;
    public string Country { get; private set; } = default!;

    private readonly List<Book> _books = new();
    public IReadOnlyCollection<Book> Books => _books;

    public Publisher(string name, string country)
    {
        Name = name;
        Country = country;
    }
    
    private Publisher() {}
    
    public void AddBook(Book book) => _books.Add(book);
    
    public void Update(Publisher publisher)
    {
        Name = publisher.Name;
        Country = publisher.Country;
    }
    
}