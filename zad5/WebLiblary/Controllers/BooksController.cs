using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLiblary.Books;
using WebLiblary.Models;
using WebLiblary.Services;

namespace WebLiblary.Controllers
{
    public class BooksController : Controller
    {
        //private readonly DataContext _context;

        private readonly ILiblaryServis _liblaryServis;

        public BooksController(ILiblaryServis liblaryServis)
        {
            _liblaryServis = liblaryServis;
        }

        // GET: Books
        public async Task<IActionResult> Index(int pg=1)
        {

            var serres = await _liblaryServis.GetProductsAsync();
            if (!serres.Success)
            {
                Problem("Problem");
            }
            var books = serres.Data.ToList();
            var pager = new Pager(books.Count(),pg);
            this.ViewBag.Pager = pager;
            var pbook = books.Skip((pg-1)*pager.PageSize).Take(pager.PageSize).ToList();
            return View(pbook);
                          
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(long? id){


            
            var respond = await _liblaryServis.GetProductAsync((long)id);
            
            if (!respond.Success)
            {
                return NotFound();
            }

            return View(respond.Data);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Description,NumberOfBooks,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = 0;
                await _liblaryServis.CreateProductAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var respond = await _liblaryServis.GetProductAsync((long)id);

            if (!respond.Success)
            {
                return NotFound();
            }

            return View(respond.Data);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Title,Author,Description,NumberOfBooks,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _liblaryServis.UpdateProductAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var respond = await _liblaryServis.GetProductAsync(id);
                    if ( !respond.Success)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var respond = await _liblaryServis.GetProductAsync((long)id);

            if (!respond.Success)
            {
                return NotFound();
            }

            return View(respond.Data);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            
            

            var respond = await _liblaryServis.DeleteProductAsync((long)id);

            if (!respond.Success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));

        }

        
    }
}
