using RestBiblioteca.model;

namespace RestBiblioteca.repository;

public interface IUserRepository
{ 
    public User Create(User user);
    
    public User? Update(long id, User user);
}