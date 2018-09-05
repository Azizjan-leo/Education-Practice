using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class BookLeaseDTO
    {
        public int LeaseId { get; set; }
        public int StudentId { get; set; }
        public StudentDTO Student { get; set; }
        public int BookId { get; set; }
        public BookDTO Book { get; set; }
        public int Amount { get; set; }
        public DateTime GetTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
