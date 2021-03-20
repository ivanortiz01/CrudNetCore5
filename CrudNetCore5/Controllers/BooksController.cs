using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Http get Index
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.books;
            return View(books);
        }

        //Http get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.books.Add(book);
                _context.SaveChanges();
                TempData["message"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Http post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.books.Update(book);
                _context.SaveChanges();
                TempData["message"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Http post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.books.Remove(book);
            _context.SaveChanges();
            TempData["message"] = "El libro se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
