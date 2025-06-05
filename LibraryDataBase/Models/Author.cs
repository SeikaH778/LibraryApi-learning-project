using ConsoleApp1;

namespace LibraryDataBase.Models
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
