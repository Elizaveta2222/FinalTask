using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lection
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public List<Homework> Homeworks { get; set; } = new(); //связь с т ДЗ (многие к одному)
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } //связь с т Преп
        public int HomeworkId { get; set; }
        public Homework Homework { get; set; } //связь с т Преп
        public List<VisitJournal> VisitJournals { get; set; } = new(); //связь с т VJ (многие ко одному)
    }
}
