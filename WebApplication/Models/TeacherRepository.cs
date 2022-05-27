using BusinessLogic.Models;
using BusinessLogic.Repositories;
namespace WebApplicationFinalTask.Models
{
    public class TeacherRepository:ITeacherRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(Teacher teacher)
        {
            db.Teachers.Add(teacher);
        }

        public void Delete(int id)
        {
            Teacher t = db.Teachers.Where(t => t.Id == id).First();
            db.Teachers.Remove(t);
        }

        public Teacher GetObject(int id)
        {
            Teacher t = db.Teachers.Where(t => t.Id == id).First();
            return t;
        }

        public IEnumerable<Teacher> GetObjectList()
        {
            var teachers = db.Teachers.ToList();
            return teachers;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            db.Teachers.Update(teacher);
        }

        public string GetNotification(string nameStudent)
        {
            string notification = "Студент " + nameStudent + " пропустил 3 занятия по вашему предмету";
            return notification;
        }
    }
}
