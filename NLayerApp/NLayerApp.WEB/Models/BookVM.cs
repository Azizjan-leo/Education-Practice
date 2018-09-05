using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class BookVM
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }


}