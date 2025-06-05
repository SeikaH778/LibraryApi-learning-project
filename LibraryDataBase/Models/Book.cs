using ConsoleApp1;
namespace LibraryDataBase.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int AuthorId { get; set; }
    }

}
