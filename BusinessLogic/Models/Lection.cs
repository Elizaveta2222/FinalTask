using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Lection
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } //связь с т Преп
        public List<Homework> Homeworks { get; set; } = new(); //связь с т Преп
        public List<VisitJournal> VisitJournals { get; set; } = new(); //связь с т VJ (многие ко одному)
    }
}
