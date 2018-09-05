using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class BookLeaseVM
    {
        public int LeaseId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime GetTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnTime { get; set; }
    }
}