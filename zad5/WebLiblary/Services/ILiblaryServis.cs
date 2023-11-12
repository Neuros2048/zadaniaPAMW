



using WebLiblary.Books;

namespace WebLiblary.Services
{
    public interface ILiblaryServis
    {
        public  Task<ServiceResponse<List<Book>>> GetProductsAsync();

        public Task<ServiceResponse<Book>> GetProductAsync(long id);

        public Task<ServiceResponse<Book>> UpdateProductAsync(Book product);

        public Task<ServiceResponse<Book>> DeleteProductAsync(long id);

        public Task<ServiceResponse<Book>> CreateProductAsync(Book product);
    }


}
