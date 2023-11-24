using mobileliblary.shared.Books;
using mobileliblary.shared.Configutations;
using mobileliblary.shared.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileliblary.services
{
    public class LiblaryServis : ILiblaryServis
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public LiblaryServis(HttpClient httpClient, AppSettings appSettings)
        {
            
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<ServiceResponse<Book>> AddProduct(Book book)
        {
            string uri = _appSettings.BaseProductEndpoints.Base_url;
            uri += string.Format(_appSettings.BaseProductEndpoints.AddProductEndpoint, book.Title, book.Author, book.Description, book.NumberOfBooks);
            HttpContent httpContent = new StringContent("");
            var response = await _httpClient.PutAsync(uri, httpContent);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
            return result;
        }

        public async Task<ServiceResponse<Book>> ChangeProduct(Book book)
        {
            string uri = _appSettings.BaseProductEndpoints.Base_url;
            uri += string.Format(_appSettings.BaseProductEndpoints.ChangeProductEndpoint, book.Title, book.Author, book.Description, book.NumberOfBooks, book.Id);
            HttpContent httpContent = new StringContent("");
            var response = await _httpClient.PostAsync(uri, httpContent);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
            return result;
        }

        public async Task<ServiceResponse<Book>> DeleteProductAsync(long id)
        {
            string uri = _appSettings.BaseProductEndpoints.Base_url;
            uri += string.Format(_appSettings.BaseProductEndpoints.DeleteProductEndpoint, id);
            var response = await _httpClient.DeleteAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
            return result;
        }


        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();        
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json);
        //    return result;
        //}


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Book>>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseProductEndpoints.Base_url + _appSettings.BaseProductEndpoints.GetAllProductsEndpoint);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            return result;
        }

  
    }
}
