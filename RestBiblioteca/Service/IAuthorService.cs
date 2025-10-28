
using RestBiblioteca.model;

namespace RestBiblioteca.service;

internal interface IAuthorService
{
 Task<IEnumerable<Author>> GetAll();
 Task<Author?> GetById(long id);
 Task<Author> Create(Author author);
 Task<Author?> Update(long id, Author author);
 Task<bool> Delete(long id);
}