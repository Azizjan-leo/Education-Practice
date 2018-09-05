using System.ComponentModel.DataAnnotations;

namespace NLayerApp.DAL.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}