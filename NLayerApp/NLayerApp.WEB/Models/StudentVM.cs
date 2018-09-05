using System.ComponentModel.DataAnnotations;

namespace NLayerApp.WEB.Models
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Group")]
        public int GroupId { get; set; }

        public virtual GroupVM Group { get; set; }
    }
}