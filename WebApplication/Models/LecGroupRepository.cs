using BusinessLogic.Models;
using BusinessLogic.Repositories;

namespace WebApplicationFinalTask.Models
{
    public class LecGroupRepository : ILecGroupRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(LecGroup lecgroup)
        {
            db.LecGroups.Add(lecgroup);
        }

        public void Delete(int id)
        {
            LecGroup lg = db.LecGroups.Where(lg => lg.Id == id).First();
            db.LecGroups.Remove(lg);
        }

        public LecGroup GetObject(int id)
        {
            LecGroup lg = db.LecGroups.Where(lg => lg.Id == id).First();
            return lg;
        }

        public IEnumerable<LecGroup> GetObjectList()
        {
            var lecgroups = db.LecGroups.ToList();
            return lecgroups;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(LecGroup lecgroup)
        {
            db.LecGroups.Update(lecgroup);
        }
    }
}
