using RestBiblioteca.model;

namespace RestBiblioteca.repository.impl;

internal sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User Create(User user)
    { 
         _dbContext.Users.Add(user);
         _dbContext.SaveChanges();
         return user;
    }

    public User? Update(long id, User user)
    {
        var userDb = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        if (userDb is null)
        {
            return null;
        }
        userDb.Update(user);
        _dbContext.SaveChanges();
        return userDb;
    }
}