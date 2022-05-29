using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFinalTask.Models
{
    public class LectionRepository : ILectionRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(Lection lection)
        {
            db.Lections.Add(lection);
        }

        public void Delete(int id)
        {
            Lection l = db.Lections.Where(l => l.Id == id).First();
            db.Lections.Remove(l);
        }

        public Lection GetObject(int id)
        {
            Lection l = db.Lections.Where(l => l.Id == id).First();
            return l;
        }

        public IEnumerable<Lection> GetObjectList()
        {
            var lections = db.Lections.Include(l=>l.Teacher).ToList();
            return lections;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Lection lection)
        {
            db.Lections.Update(lection);
        }
    }
}
