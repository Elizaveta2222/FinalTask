using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<VisitJournal> VisitJournals { get; set; } = new(); //связь с т VJ (многие ко одному)
        public int LecGroupId { get; set; } //связь с т группой
        public LecGroup LecGroup { get; set; }
    }
}
