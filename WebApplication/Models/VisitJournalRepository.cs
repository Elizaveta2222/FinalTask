using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFinalTask.Models
{
    public class VisitJournalRepository : IVisitJournalRepository
    {
        private readonly ILogger<VisitJournalRepository> logger;

        public VisitJournalRepository(ILogger<VisitJournalRepository> logger)
        {
            this.logger = logger;
        }

        private ApplicationContext db = new ApplicationContext();

        public void Create(VisitJournal vj)
        {
            db.VisitJournals.Update(vj);
            db.SaveChanges();
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
            var vj = db.VisitJournals.Include(vj=>vj.Lection).Include(vj=>vj.Student).ToList();
            return vj;
        }

        public void Save()
        {
            db.SaveChanges();
            CheckAbsence();
            CheckMarks();
        }

        public void Update(VisitJournal vj)
        {
            var last = db.VisitJournals.Where(j => j.Id == vj.Id).Include(j => j.Student).Include(j => j.Lection).FirstOrDefault();
            last.Mark = vj.Mark;
            db.VisitJournals.Update(last);
            db.SaveChanges();
        }
        public void CheckAbsence()
        {
            var students=db.VisitJournals.Select(j=>j.Student.Id).Distinct().ToList();
            foreach(var student in students)
            {
                var subj=db.VisitJournals.Where(j => j.Student.Id==student).Select(j=>j.Lection.Subject).Distinct().ToList();
                foreach (var sub in subj)
                {
                    var attendance=db.VisitJournals.Where(j=>j.Student.Id==student).Where(j=>j.Lection.Subject==sub).Where(j=>j.Mark==VisitJournal.Marks.Absence).Count();
                    if (attendance >= 3)
                    {
                        Student s=db.Students.Where(s=>s.Id==student).First();
                        Lection l = db.Lections.Where(l => l.Subject == sub).Include(l=>l.Teacher).First();
                        string studmess = "Вы пропустили больше трех занятий по предмету " + l.Subject;
                        string teachmess = "Студент " + s.Name + " " + s.Surname + " пропустил более трех занятий по вашему предмету";
                        logger.LogInformation("\nEmail: {ST}\n{t}\n", s.Email, studmess);
                        logger.LogInformation("\nEmail: {ST}\n{t}\n", l.Teacher.Email, teachmess);
                    }
                }
            }
            
        }
        public void CheckMarks()
        {
            var students = db.VisitJournals.Select(j => j.Student.Id).Distinct().ToList();
            foreach (var student in students)
            {
                var subj = db.VisitJournals.Where(j => j.Student.Id == student).Select(j => j.Lection.Subject).Distinct().ToList();
                foreach (var sub in subj)
                {
                    var marks = db.VisitJournals.Where(j => j.Student.Id == student).Where(j => j.Lection.Subject == sub);
                    var avr = 0;
                    foreach (var mark in marks)
                    {
                        if ((int)mark.Mark == -1)
                        {
                            avr += 0;
                        }
                        else
                        {
                            avr += (int)mark.Mark;
                        }
                    }
                    avr = avr / sub.Count();
                    if (avr < 4)
                    {
                        Student s = db.Students.Where(s => s.Id == student).First();
                        Lection l = db.Lections.Where(l => l.Subject == sub).First();
                        string studmess = "Ваша оценка по предмету " + sub + " меньше 4";
                        logger.LogInformation("\nPhone: {ST}\n{t}\n", s.Phone, studmess);
                    }
                }
            }
        }
    }
}
