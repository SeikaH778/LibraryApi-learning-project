namespace LibraryApi.DTO
{
    public class AuthorResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookSummaryDto> Books { get; set; } = new();
    }
}
