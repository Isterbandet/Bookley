using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookley.Models;
using Bookley.Dtos;
using AutoMapper;

namespace Bookley.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Book.ToList().Select(Mapper.Map<Book, BookDto>);
        }

        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return NotFound();
            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Book.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }
        [HttpPut]
        public IHttpActionResult UppdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                return NotFound();
            Mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                return NotFound();
            _context.Book.Remove(bookInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
