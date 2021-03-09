using IT_Postman.Models;
using IT_Postman.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IT_Postman.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService authorService)
        {
            _bookService = authorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("{authorId}")]
        public ActionResult<Book> Get(Guid authorId)
        {
            var result = _bookService.GetBook(authorId);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] NewBook newAuthor)
        {
            if (string.IsNullOrWhiteSpace(newAuthor.Title)
                || string.IsNullOrWhiteSpace(newAuthor.Author)
                || string.IsNullOrWhiteSpace(newAuthor.Publisher)
                )
            {
                return BadRequest();
            }
            var createdBook = _bookService.Create(newAuthor.Title, newAuthor.Author, newAuthor.Publisher);
            return Created("myUri", createdBook);
        }
    }

    public class NewBook
    {
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
    }
}
