namespace RestBiblioteca.model;

public class Book
{
    public Guid Id {get; private set; }
    public string Name { get; private set; } = default!;
    
    public Guid AuthorId {get; private set;}
    public Author Author { get; private set; } = default!;
    public Category Category { get; private set; }
    
    public Guid PublisherId {get; private set;}
    public Publisher Publisher { get; private set; } = default!;

    public Book(string name, Guid authorId, Guid publisherId, Category category)
    {
        Name = name;
        AuthorId = authorId;
        PublisherId = publisherId;
        Category = category;
    }
    
    private Book() {}
    
    

    public void Update(Book book)
    {
        Name = book.Name;
        AuthorId = book.AuthorId;
        Category = book.Category;
        PublisherId = book.PublisherId;
    }
}