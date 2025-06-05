namespace LibraryApi.DTO
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
