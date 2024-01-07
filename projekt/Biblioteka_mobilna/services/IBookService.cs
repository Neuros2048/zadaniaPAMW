using shared.Books;
using shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka_mobilna.services
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
