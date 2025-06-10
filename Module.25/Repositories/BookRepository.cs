using Microsoft.EntityFrameworkCore;
using Module._25.Entities;

namespace Module._25.Repositories;
/// <summary>
/// Репозиторий книги
/// </summary>
/// <param name="appContext"></param>
public class BookRepository(AppContext appContext) : IBookRepository
{
    private AppContext _appContext = appContext;

    public Book Create(Book book)
    {
        if (book == null) throw new ArgumentNullException("book");

        _appContext.Entry(book).State = EntityState.Added;

        _appContext.SaveChanges();

        return book;
    }

    public void Delete(Book book)
    {
        if (book == null) throw new ArgumentNullException("book");

        _appContext.Entry(book).State = EntityState.Deleted;

        _appContext.SaveChanges();
    }

    public Book Get(int id)
    {
        return _appContext.Books.FirstOrDefault(b => b.Id == id);
    }

    public List<Book> GetAll()
    {
        return _appContext.Books.ToList();
    }

    public List<Book> GetAllBySortByTitle()
    {
        return _appContext.Books.OrderBy(b => b.Title).ToList();
    }

    public List<Book> GetAllByYearDesc()
    {
        return _appContext.Books.OrderByDescending(b => b.YearWritind).ToList();
    }

    public List<Book> GetByAuthor(string author)
    {
        var name = _appContext.Books.Where(b => b.Author.Name == author).ToList();
        return _appContext.Books.Where(b => b.Author.Name == author).ToList();
    }

    public List<Book> GetByGenre(string genre)
    {
        return _appContext.Books.Where(b => b.Genre.Name == genre).ToList();
    }

    public List<Book> GetByYearAndGenre(int year1, int year2, string genre)
    {
        return _appContext.Books.Where(b => b.YearWritind >= year1 && b.YearWritind <= year2 && b.Genre.Name == genre).ToList();
    }

    public int GetCountByAuthor(string author)
    {
        return _appContext.Books.Where(b => b.Author.Name == author).Count();
    }

    public int GetCountByGenre(string genre)
    {
        return _appContext.Books.Where(b => b.Genre.Name == genre).Count();
    }

    public bool HasAuthorAndGenre(string author, string genre)
    {
        return _appContext.Books.Where(b => b.Author.Name == author && b.Genre.Name == genre).Any();
    }

    public Book LastYear()
    {
        return _appContext.Books.OrderBy(b => b.YearWritind).Last();
    }

    public Book Update(Book book)
    {
        if (book == null) throw new ArgumentNullException("book");

        _appContext.Entry(book).State = EntityState.Modified;

        _appContext.SaveChanges();

        return book;
    }
}
