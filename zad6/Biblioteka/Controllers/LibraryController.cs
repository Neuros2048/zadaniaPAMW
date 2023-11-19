using Microsoft.AspNetCore.Mvc;

using Biblioteka.Services;
using shared.service;
using shared.Books;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {

      

        private readonly ILiblaryServis _liblaryService;

        public LibraryController(ILiblaryServis liblaryService)
        {
            _liblaryService = liblaryService;
        }
        // GET: api/<LibraryController>

        // GET api/<LibraryController>/5
        [HttpGet("getBook")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetAsync(int id)
        {

            
            var result = await _liblaryService.GetProductAsync(id);
            if (result.Success)
                return Ok(result);
            else
                //return StatusCode(500, $"Internal server error {result.Message}");
                return StatusCode(500, result);

        }

        [HttpGet("getBooksList")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetListAsync()
        {

            
            var result = await _liblaryService.GetProductsAsync();
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, result);
            //return StatusCode(500, $"Internal server error {result.Message}");

        }



        // POST api/<LibraryController>
        [HttpPost("changeBook")]
        public async Task<ActionResult<ServiceResponse<Book>>> Post([FromQuery] Book value)
        {
            var result = await _liblaryService.UpdateProductAsync(value);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, result);
            //return StatusCode(500, $"Internal server error {result.Message}");
        }

        // PUT api/<LibraryController>/5
        [HttpPut("addBook")]
        public async Task<ActionResult<ServiceResponse<Book>>> Put( [FromQuery] Book value)
        {
            var result = await _liblaryService.CreateProductAsync(value);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, result);
            //return StatusCode(500, $"Internal server error {result.Message}");
        }


        // DELETE api/<LibraryController>/5
        [HttpDelete("deleteBook")]
        public async Task<ActionResult<ServiceResponse<Book>>> Delete(int id)
        {
            var result = await _liblaryService.DeleteProductAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, result);
            //return StatusCode(500, $"Internal server error {result.Message}");
        }
    }
}
