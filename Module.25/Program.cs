using Module._25.Entities;
using Module._25.Repositories;
using System.Net.WebSockets;

namespace Module._25;

internal class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var bookRep = new BookRepository(db);
            var userRep = new UserRepository(db);

            foreach (var item in bookRep.GetAllByYearDesc())
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine(bookRep.GetCountByAuthor("Polan"));
            Console.WriteLine(bookRep.HasAuthorAndGenre("Polan", "Drama"));
            Console.WriteLine(userRep.HasBook("Cry", 1));
            Console.WriteLine(userRep.GetBookCount(1));
            Console.WriteLine(bookRep.LastYear().Title);
        }
    }
}
