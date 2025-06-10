using Module._25.Entities;

namespace Module._25.Repositories;
/// <summary>
/// Интерфейс для репозитория книги
/// </summary>
public interface IBookRepository
{
    public Book Create(Book book);
    public Book Update(Book book);
    public void Delete(Book book);
    public Book Get(int id);
    public List<Book> GetAll();

    public List<Book> GetByYearAndGenre(int year1, int year2, string genre);
    public List<Book> GetByGenre(string genre);
    public List<Book> GetByAuthor(string author);
    public bool HasAuthorAndGenre(string author, string genre);
    public Book LastYear();
    public List<Book> GetAllBySortByTitle();
    public List<Book> GetAllByYearDesc();
    public int GetCountByGenre(string genre);
    public int GetCountByAuthor(string author);
}
