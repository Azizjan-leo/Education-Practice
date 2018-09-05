using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class GroupVM
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<StudentVM> Students { get; set; }
    }
}