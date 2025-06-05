using Microsoft.AspNetCore.Mvc;
using LibraryDataBase.Models;
using ConsoleApp1;
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
        public async Task<ActionResult<Book>> Create(Book book)
        {
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
        public IActionResult Update(int id)
        {
            var Foundbook = _bookRepository.FindById(id);
            if (Foundbook == null)
            {
                return NotFound();
            }
            _bookRepository.Update(Foundbook);
            return NoContent();
        }
    }
}

