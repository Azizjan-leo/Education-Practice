using System.ComponentModel.DataAnnotations;

namespace NLayerApp.DAL.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}