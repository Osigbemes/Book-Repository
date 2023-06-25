using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Controllers
{
    [Route("api/[Controller]")]
    public class BooksController : ControllerBase
    {
        //private BookRepository books = new BookRepository();
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Add(Book book)
        {
            var result = await _bookRepository.Add(book);
            
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Id mismatch");
            }

            var result = await _bookRepository.Update(id, book);
            if (result == null)
            {
                return NoContent();
            }
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }
    }
}

