using Biblioteka.Books;

namespace Biblioteka.Services
{
    public interface ILiblaryServis
    {
        public  Task<ServiceResponse<List<Book>>> GetProductsAsync();
    }
}
