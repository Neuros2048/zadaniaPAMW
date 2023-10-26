using Microsoft.AspNetCore.Mvc;
using Biblioteka.Books;
using Biblioteka.Services;

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

            if(id < 1 || id > 10)
            {
                return StatusCode(404, $"Book of this id dont exist");
            }
            var result = await _liblaryService.GetProductsAsync();
            if (result.Success)
                return Ok(result.Data[id - 1]);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
                
        }

        [HttpGet("getBooksList")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetListAsync()
        {

            
            var result = await _liblaryService.GetProductsAsync();
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result}");

        }



        // POST api/<LibraryController>
        [HttpPost("changeBook")]
        public IActionResult Post([FromQuery] Book value)
        {
            return Ok($"Book of id {0}, has been changed");
        }

        // PUT api/<LibraryController>/5
        [HttpPut("addBook")]
        public IActionResult Put( [FromQuery] Book value)
        {
            return Ok($"Book of id {0}, has been added");
        }


        // DELETE api/<LibraryController>/5
        [HttpDelete("deleteBook")]
        public IActionResult Delete(int id)
        {
            if(id < 0)
            {
                return BadRequest("Wronng indeks");
            }
            return Ok($"Book of id {id}, has been delated");
        }
    }
}
