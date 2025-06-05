using ConsoleApp1;
using LibraryApi.DTO;
using LibraryDataBase.Models;
using Microsoft.AspNetCore.Mvc;
namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:ControllerBase 
    {
        private readonly IRepository<Book> _bookRepository;
        public BooksController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book =  _bookRepository.FindById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] BookDto bookDto)
        {
            var authorExists = _bookRepository.FindById(bookDto.AuthorId);
            if (authorExists == null)
            {
                return BadRequest($"Author with ID {bookDto.AuthorId} does not exist");
            }

            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId
            };

            _bookRepository.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             _bookRepository.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookDto bookDto)
        {
            var Foundbook = _bookRepository.FindById(id);
            if (Foundbook == null)
            {
                return NotFound();
            }
            Foundbook.Title = bookDto.Title;
            _bookRepository.Update(Foundbook);
            return NoContent();
        }
    }
}

