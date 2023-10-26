using Biblioteka.Books;

namespace Biblioteka.Services
{
    public class LiblaryServis : ILiblaryServis
    {
        public async Task<ServiceResponse<List<Book>>> GetProductsAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.GenerateBooksData(),
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
    }
}
