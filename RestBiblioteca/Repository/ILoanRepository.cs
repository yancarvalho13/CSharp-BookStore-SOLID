using RestBiblioteca.model;

namespace RestBiblioteca.repository;

internal interface ILoanRepository
{
    Task CreateAsync(Loan loan);
    
}