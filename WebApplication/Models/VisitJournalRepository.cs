using BusinessLogic.Models;
using BusinessLogic.Repositories;

namespace WebApplicationFinalTask.Models
{
    public class VisitJournalRepository : IVisitJournalRepository
    {
        private ILogger<VisitJournalRepository> logger;
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
                    Lection l = attendance.First().Lection;
                    string studmess = "Вы пропустили больше трех занятий по предмету " + l.Subject;
                    string teachmess = "Студент " + s.Name + " " + s.Surname + " пропустил более трех занятий по вашему предмету";
                    logger.LogInformation("\nEmail: {ST}\n{t}\n", s.Email, studmess);
                    logger.LogInformation("\nEmail: {ST}\n{t}\n", l.Teacher.Email, teachmess);
                }
            }
        }
        public void CheckMarks()
        {
            var studLec = db.VisitJournals.GroupBy(a => new { a.Student, a.Lection.Subject });
            foreach(var group in studLec)
            {
                var avgMark = 0;
                foreach(var lec in group)
                {
                    if ((int)lec.Mark == -1)
                    {
                        avgMark += 0;
                    }
                    else
                    {
                        avgMark+=(int)lec.Mark;
                    }
                }
                avgMark = avgMark / group.Count();
                if (avgMark < 4)
                {
                    Student s = group.First().Student;
                    Lection l = group.First().Lection;
                    string studmess = "Ваша оценка по предмету " + l.Subject+" меньше 4";
                    logger.LogInformation("\nPhone: {ST}\n{t}\n", s.Phone, studmess);
                }
            }
        }
    }
}
