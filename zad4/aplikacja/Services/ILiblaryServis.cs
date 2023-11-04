using shared.Books;
using shared.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface ILiblaryServis
    {
        Task<ServiceResponse<List<Book>>> GetProductsAsync();
        Task<ServiceResponse<Book>> DeleteProductAsync(long id);
        Task<ServiceResponse<Book>> ChangeProduct(Book book);
        Task<ServiceResponse<Book>> AddProduct(Book book);
    }
}
