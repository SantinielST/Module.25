using Microsoft.EntityFrameworkCore;
using Module._25.Entities;

namespace Module._25.Repositories;

public class UserRepository(AppContext appContext) : IUserRepository
{
    private AppContext _appContext = appContext;

    public User Create(User user)
    {
        if (user == null) throw new ArgumentNullException("user");

        _appContext.Entry(user).State = EntityState.Added;

        _appContext.SaveChanges();
        
        return user;
    }

    public void Delete(User user)
    {
        if (user == null) throw new ArgumentNullException("user");

        _appContext.Entry(user).State = EntityState.Deleted;

        _appContext.SaveChanges();
    }

    public User Get(int id)
    {
        return _appContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAll()
    {
        return _appContext.Users.ToList();
    }

    public int GetBookCount(int id)
    {
        return _appContext.Users.Where(u => u.Id == id).Sum(u => u.Books.Count);
    }

    public bool HasBook(string bookTitle, int id)
    {
       return _appContext.Users.Where(u => u.Id == id).Select(u => u.Books.Where(b => b.Title == bookTitle)).Any();
    }

    public User Update(User user)
    {
        if (user == null) throw new ArgumentNullException("user");

        _appContext.Entry(user).State = EntityState.Modified;

        _appContext.SaveChanges();

        return user;
    }
}
