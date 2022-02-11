using LibApp.Data;
using LibApp.Models;
using LibApp.Respositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRep;
    
        public BooksController(ApplicationDbContext context)
        {
            _bookRep = new BookRepository(context);
        }

        // GET api/books/
        [HttpGet]
        public IEnumerable<Book> GetBooks() => _bookRep.GetBooks();

        // GET api/books/
        [HttpGet("{id:int}")]
        public Book GetBookById(int id) => _bookRep.GetBookById(id);

        [HttpDelete("{id:int}")]
        public void Delete(int id) => _bookRep.Delete(id);

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();

                await _bookRep.AddAsync(book);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public void Update(int id) => _bookRep.Update(_bookRep.GetBookById(id));

    }
}
