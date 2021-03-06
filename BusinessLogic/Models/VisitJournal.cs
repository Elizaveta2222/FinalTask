using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class VisitJournal
    {
        public int Id { get; set; }
        public Marks? Mark { get; set; }
        public enum Marks : int
        {
            NoHomework = 0,
            A = 5,
            B = 4,
            C = 3,
            D = 2,
            E = 1,
            Absence = -1
        }
        public Lection Lection{ get; set; } //связь с т студенты (многие ко одному)
        public Student Student { get; set; }  //связь с т студенты (многие ко одному)
    }
}
