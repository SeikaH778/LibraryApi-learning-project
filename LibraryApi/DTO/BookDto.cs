using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }

}
