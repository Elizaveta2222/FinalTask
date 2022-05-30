using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFinalTask.Models
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(Homework homework)
        {
            db.Homeworks.Add(homework);
        }

        public void Delete(int id)
        {
            Homework h=db.Homeworks.Where(h => h.Id == id).First();
            db.Homeworks.Remove(h);
        }

        public Homework GetObject(int id)
        {
            Homework h = db.Homeworks.Where(h => h.Id == id).First();
            return h;
        }

        public IEnumerable<Homework> GetObjectList()
        {
            var homeworks=db.Homeworks.Include(h => h.Lection).Include(h=>h.Lection.Teacher).ToList();
            return homeworks;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Homework homework)
        {
            db.Homeworks.Update(homework);
        }
    }
}
