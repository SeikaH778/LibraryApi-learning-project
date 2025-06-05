using Microsoft.AspNetCore.Mvc;
using LibraryDataBase.Models;
using ConsoleApp1;
namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController:ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorsController(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAll()
        {
            return Ok(_authorRepository.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var author = _authorRepository.FindById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            _authorRepository.Add(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorRepository.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        { 
            var Foundauthor = _authorRepository.FindById(id);
            if(Foundauthor == null)
            {
                return NotFound();
            }

            _authorRepository.Update(Foundauthor);
            return NoContent();
        }
    }
}
