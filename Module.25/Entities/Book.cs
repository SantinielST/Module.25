namespace Module._25.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int YearWritind { get; set; }

    public int GenreID { get; set; }
    public Genre Genre { get; set; }

    public int AuthorID { get; set; }
    public Author Author { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public bool Issued { get; set; } = false;
}
