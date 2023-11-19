using shared.Books;
using webliblary.Models;

namespace webliblary.services
{
    public interface IBookService
    {
        List<Book> books { get; set; }

        Task<Book?> GetBookAsync(long id);
        Task GetBooksAsync(int page);
        Task DeleteBookAsync(long id);
        Task ChangeBook(Book book);
        Task AddBook(Book book);
        public Pager getPager();

    }
}
