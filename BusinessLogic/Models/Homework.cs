using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Lection Lection { get; set; }
    }
}
