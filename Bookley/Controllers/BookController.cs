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
            //var books = _context.Book.Include(m => m.GenreId).ToList();
            var books = _context.Book.Include(m => m.Genre).ToList();
            // return View(books);
            //var books = _context.Book.ToList();
            return View(books);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormsViewModel
            {
                Genres = genres
            };
            return View("New", viewModel);

        }

        public ActionResult Edit(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormsViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }




        public ActionResult Details(int id)
        {
            var book = _context.Book.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost]
        public ActionResult Save(Book book)
        {

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                book.Publish_date = DateTime.Now;
                book.Publish_date = DateTime.Now;
                book.Id = 7;
                _context.Book.Add(book);
            }
            else
            {
                var bookInDb = _context.Book.Single(m => m.Id == book.Id);
                bookInDb.Title = book.Title;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.Description = book.Description;

                /*
                
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.Description = book.Description;
                bookInDb.Price = book.Price;
                bookInDb.Genre = book.Genre;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.Publish_date = book.Publish_date;
                */

                //TryUpdateModel(bookInDb);

            }

            //book.Genre = new Genre { };

            //_context.Book.Add(book);

            _context.SaveChanges();



            return RedirectToAction("Index", "Book");



        }






        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Book() { Author = "Shrek!" };


            var viewModel = new RandomBookViewModel
            {
                Book = movie,

            };

            return View(viewModel);
        }
    }
}
    