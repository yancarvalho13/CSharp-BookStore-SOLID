namespace RestBiblioteca.model;

public class Author
{
    public Guid Id {get; private set; }
    public string Name { get; private set; } = default!;
    public DateTime BirthDate {get; private set; } 
    public string Nationality {get; private set;}

    private readonly List<Book> _books = new();
    public IReadOnlyCollection<Book> Books => _books;

    public Author(string name, DateTime birthDate, string nationality)
    {
        Name = name;
        BirthDate = birthDate;
        Nationality = nationality;
    }
    
    public Author() {}
    
    public void AddBook(Book book) => _books.Add(book);

    public void Update(Author author)
    {
        Name = author.Name;
        BirthDate = author.BirthDate;
        Nationality = author.Nationality;
    }
}