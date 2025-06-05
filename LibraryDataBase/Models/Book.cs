using ConsoleApp1;
using System.Text.Json.Serialization;
namespace LibraryDataBase.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }    
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public decimal Price { get; set; } = 0m;
        public bool Available { get; set; } = true;
        public int AuthorId { get; set; }
    }

}
