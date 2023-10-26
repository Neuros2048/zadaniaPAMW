using Biblioteka.Services;
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
    }
}
