using mobileliblary.shared.Books;
using mobileliblary.shared.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileliblary.services
{
    public interface ILiblaryServis
    {
        Task<ServiceResponse<List<Book>>> GetProductsAsync();
        Task<ServiceResponse<Book>> DeleteProductAsync(long id);
        Task<ServiceResponse<Book>> ChangeProduct(Book book);
        Task<ServiceResponse<Book>> AddProduct(Book book);
    }
}
