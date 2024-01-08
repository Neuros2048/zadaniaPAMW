using shared.Books;
using shared.Models;
using shared.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace shared.services
{
    public class BookService : IBookService
    {
        public List<Book> books { get; set; } = new List<Book>();

        private readonly HttpClient _client;

        public Pager pager { get; set; } = new Pager(0, 1);

        public BookService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<Book?> GetBookAsync(long id)
        {

            var result = await _client.GetAsync($"api/Library/getBook?id={id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var res = await _client.GetFromJsonAsync<ServiceResponse<Book?>>($"api/Library/getBook?id={id}");
                return res.Data;
            }

            return null;
        }

        public async Task GetBooksAsync(int page)
        {


            var result = await _client.GetFromJsonAsync<ServiceResponse<List<Book>>>("api/Library/getBooksList");

            if (result != null && result.Success)
            {

                pager = new Pager(result.Data.Count(), page);
                books = result.Data.ToList().Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();

            }


        }

        public async Task DeleteBookAsync(long id)
        {
            await _client.DeleteAsync($"api/Library/deleteBook?id={id}");
        }

        public async Task ChangeBook(Book book)
        {
            string uri = string.Format("api/Library/changeBook?Title={0}&Author={1}&Description={2}&NumberOfBooks={3}&Id={4}", book.Title, book.Author, book.Description, book.NumberOfBooks, book.Id);
            HttpContent httpContent = new StringContent("");
            await _client.PostAsync(uri, httpContent);
        }

        public async Task AddBook(Book book)
        {
            string uri = string.Format("api/Library/addBook?Title={0}&Author={1}&Description={2}&NumberOfBooks={3}", book.Title, book.Author, book.Description, book.NumberOfBooks);
            HttpContent httpContent = new StringContent("");
            var res = await _client.PutAsync(uri, httpContent);
        }



        public Pager getPager()
        {
            return pager;
        }
    }
}
