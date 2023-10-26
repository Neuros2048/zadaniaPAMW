using Biblioteka.Books;
using Bogus;

namespace Biblioteka.Services
{
    public class BookSeeder
    {

        public static List<Book> GenerateBooksData()
        {
            int productId = 1;
            var productFaker = new Faker<Book>()
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Author, x=> x.Name.FirstName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.NumberOfBooks, x=> x.Random.Int(1,30))
                .RuleFor(x => x.Id, x => productId++);
               

            return productFaker.Generate(10).ToList();

        }



    }
}
