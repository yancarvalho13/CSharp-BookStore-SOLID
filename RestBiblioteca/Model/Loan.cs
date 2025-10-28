namespace RestBiblioteca.model;

internal class Loan
{
    public long Id { get; private set; }
    public long BookId { get; private set; }
    
    public Book Book { get; private set; } = null!;
    
    public User User { get; private set; } = null!;
    public long UserId { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    
    public Loan(){}
    
    public Loan(long bookId, long userId, DateTime loanDate, DateTime returnDate)
    {
        BookId = bookId;
        UserId = userId;
        LoanDate = loanDate;
        ReturnDate = returnDate;
    }
    
    
    
}