using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NLayerApp.DAL.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }

       public virtual ICollection<Student> Students { get; set; }
    }
}