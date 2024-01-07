
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using shared.Books;
using shared.service;

namespace Biblioteka.Services
{
    public class LiblaryServis : ILiblaryServis
    {

        private readonly DataContext _dataContext;
        public LiblaryServis(DataContext dataContext) { 
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Book>> CreateProductAsync(Book product)
        {
            try
            {
                await _dataContext.Products.AddAsync(product);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book>() { Data = product, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = product,
                    Success = false,
                    Message = "Cannot create book"
                };
            }
        }

        public async Task<ServiceResponse<Book>> DeleteProductAsync(long id)
        {
            
            
            try
            {
                Book book = _dataContext.Products.Find(id);
                if (book == null) return new ServiceResponse<Book>() { Data = book, Success = false, Message = $"Book of id {id} dont exits" };
                _dataContext.Products.Remove(book);
                await _dataContext.SaveChangesAsync();
                var response = new ServiceResponse<Book>()
                {
                    Data = book,
                    Message = "Book was delated",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Book>> GetProductAsync(long id)
        {
            try
            {
                Book book = _dataContext.Products.Find(id);
                if(book == null) return new ServiceResponse<Book>() { Data = book, Success = false,Message=$"Book of id {id} dont exits" };

                return new ServiceResponse<Book>() { Data = book, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Success = false,
                    Message = "Problem with database"
                };
            }
        }

        public async Task<ServiceResponse<List<Book>>> GetProductsAsync()
        {

            var books = await _dataContext.Products.ToListAsync();
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = books,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }

        }

        public async Task<ServiceResponse<Book>> UpdateProductAsync(Book product)
        {
            try
            {
                var productToEdit = new Book() { Id = product.Id };
                _dataContext.Products.Attach(productToEdit);

                productToEdit.Title = product.Title;
                productToEdit.Description = product.Description;
                productToEdit.Author = product.Author;
                productToEdit.NumberOfBooks = product.NumberOfBooks;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book> { Data = productToEdit, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>
                {
                    Data = product,
                    Success = false,
                    Message = "An error occured while updating product"
                };
            }
        }
    }
}
