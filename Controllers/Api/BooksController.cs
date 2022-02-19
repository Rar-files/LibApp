using LibApp.Data;
using LibApp.Models;
using LibApp.Dtos;
using LibApp.Respositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRep;
        private readonly IMapper _mapper;
    
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _bookRep = new BookRepository(context);
            _mapper = mapper;
        }

        // GET api/books/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                var books = (await _bookRep.GetAsync())
                .ToList()
                .Select(_mapper.Map<Book, BookDto>);

                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while getting records");
            }
        }

        // GET api/books/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            try
            {
                var result = await _bookRep.GetByIdAsync(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while getting record");
            }
        }

        // Delete api/books/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var bookToDelete = await _bookRep.GetByIdAsync(id);

                if (bookToDelete == null)
                    return NotFound($"Book with Id = {id} not found");

                await _bookRep.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while deleting record");
            }
        }

        // Post api/books/
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
                    "Error creating new record");
            }
        }

        // Put api/books/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, Book book)
        {
            try
            {
                if (id != book.Id)
                    return BadRequest("Book ID mismatch");

                var bookToUpdate = await _bookRep.GetByIdAsync(id);

                if (bookToUpdate == null)
                    return NotFound($"Book with Id = {id} not found");

                await _bookRep.UpdateAsync(book);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}
