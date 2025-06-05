using ConsoleApp1;
using LibraryApi.DTO;
using LibraryDataBase.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<AuthorResponseDto>> GetAll()
        {
            var authors = _authorRepository.GetAll();
            var response = authors.Select(a => new AuthorResponseDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Books = a.Books.Select(b => new BookSummaryDto
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList()
            });

            return Ok(response);
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
        public ActionResult<Author> Create([FromBody] AuthorDTO authorDto)
        {
            var author = new Author
            {
                FirstName = authorDto.authorFirstName,
                LastName = authorDto.authorLastName,
            };

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
        public IActionResult Update(int id, [FromBody] AuthorDTO authorDto)
        { 
            var Foundauthor = _authorRepository.FindById(id);
            if(Foundauthor == null)
            {
                return NotFound();
            }
            Foundauthor.FirstName = authorDto.authorFirstName;
            Foundauthor.LastName = authorDto.authorLastName;
            _authorRepository.Update(Foundauthor);
            return NoContent();
        }
    }
}
