using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationFinalTask.Models
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(Student student)
        {
            db.Students.Add(student);
        }

        public void Delete(int id)
        {
            Student s = db.Students.Where(s => s.Id == id).First();
            db.Students.Remove(s);
        }

        public Student GetObject(int id)
        {
            Student s = db.Students.Where(s => s.Id == id).First();
            return s;
        }

        public IEnumerable<Student> GetObjectList()
        {
            var students = db.Students.Include(s => s.LecGroup).ToList();
            return students;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Student students)
        {
            db.Students.Update(students);
        }

        public string  GetNotification(string mess)
        {
            string notification = "Вы пропустили 3 занятия по предмету" + mess;
            return notification;
        }
    }
}
