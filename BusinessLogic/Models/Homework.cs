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
        public int LectionId { get; set; } //связь с т Лекции
        public Lection Lection { get; set; }
    }
}
