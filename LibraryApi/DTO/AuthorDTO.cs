namespace LibraryApi.DTO
{
    public class AuthorDTO
    {
        public string authorFirstName { get; set; } = string.Empty;
        public string authorLastName { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public List<string> Books { get; set; } = new();
    }
}
