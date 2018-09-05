using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerApp.DAL.Entities
{
    public class BookLease
    {
        [Key]
        public int LeaseId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime GetTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnTime { get; set; }

       
    }
}