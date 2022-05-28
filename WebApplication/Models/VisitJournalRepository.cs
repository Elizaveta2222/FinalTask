using BusinessLogic.Models;
using BusinessLogic.Repositories;

namespace WebApplicationFinalTask.Models
{
    public class VisitJournalRepository : IVisitJournalRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(VisitJournal vj)
        {
            db.VisitJournals.Add(vj);
        }

        public void Delete(int id)
        {
            VisitJournal vj = db.VisitJournals.Where(vj => vj.Id == id).First();
            db.VisitJournals.Remove(vj);
        }

        public VisitJournal GetObject(int id)
        {
            VisitJournal vj = db.VisitJournals.Where(vj => vj.Id == id).First();
            return vj;
        }

        public IEnumerable<VisitJournal> GetObjectList()
        {
            var vj = db.VisitJournals.ToList();
            return vj;
        }

        public void Save()
        {
            db.SaveChanges();
            CheckAbsence();
        }

        public void Update(VisitJournal vj)
        {
            db.VisitJournals.Update(vj);
        }
        public void CheckAbsence()
        {
            var attendances = db.VisitJournals.Where(m => m.Mark == VisitJournal.Marks.Absence).GroupBy(a => new {a.Student,a.Lection.Subject});
            foreach(var attendance in attendances)
            {
                if(attendance.Count() > 3)
                {
                    Student s = attendance.First().Student;
                    Teacher t = attendance.First().Lection.Teacher;
                }
            }
        }
    }
}
