using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookley.Models;
using Bookley.ViewModels;
using System.Data.Entity;

namespace Bookley.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
          var books = _context.Book.Include(m => m.Genre).ToList();
            return View(books);
        }
        public ActionResult Details(int id)
        {
            var book = _context.Book.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (book == null)
                return HttpNotFound();
            return View(book);
        }
            // GET: Movies/Random
            public ActionResult Random()
        {
            var movie = new Book() { Author = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomBookViewModel
            {
                Book = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
    