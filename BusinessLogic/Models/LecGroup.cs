using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class LecGroup
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Student> Students { get; set; } = new(); //связь с т студенты (многие ко одному)
    }
}
