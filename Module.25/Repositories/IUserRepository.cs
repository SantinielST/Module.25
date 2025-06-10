using Module._25.Entities;

namespace Module._25.Repositories;
/// <summary>
/// интерфейс для репозитория пользователя
/// </summary>
public interface IUserRepository
{
    public User Create(User user);
    public User Update(User user);
    public void Delete(User user);
    public User Get(int id);
    public List<User> GetAll();

    public bool HasBook(string bookTitle, int id);
    public int GetBookCount(int id);
}
