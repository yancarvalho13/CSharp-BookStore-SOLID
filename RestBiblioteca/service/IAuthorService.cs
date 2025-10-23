
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IAuthorService
{
 Task<IEnumerable<Author>> GetAllAsync();
 Task<Author?> GetByIdAsync(long id);
 Task<Author> CreateAsync(Author author);
 Task<Author?> UpdateAsync(long id, Author author);
 Task<bool> DeleteAsync(long id);
}