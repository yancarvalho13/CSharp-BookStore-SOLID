
using RestBiblioteca.model;

namespace RestBiblioteca.service;

public interface IAuthorService
{
 Task<IEnumerable<Author>> GetAllAsync();
 Task<Author?> GetByIdAsync(Guid id);
 Task<Author> CreateAsync(Author author);
 Task<Author?> UpdateAsync(Guid id, Author author);
 Task<bool> DeleteAsync(Guid id);
}