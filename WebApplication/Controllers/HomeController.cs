using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationFinalTask.Models;

namespace WebApplicationFinalTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;

        public HomeController(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        HomeworkRepository homeworkRepository = new HomeworkRepository();
        LecGroupRepository lecGroupRepository = new LecGroupRepository();
        LectionRepository lectionRepository = new LectionRepository();
        StudentRepository studentRepository = new StudentRepository();
        TeacherRepository teacherRepository = new TeacherRepository();
        VisitJournalRepository visitJournalRepository = new VisitJournalRepository();


        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            var teachers = teacherRepository.GetObjectList();
            return View(teachers);
        }


        //----------СОЗДАНИЕ ОБЪКТОВ----------------------------

        [HttpGet]
        public IActionResult CreateTeacher()
        {
            Teacher teacher = new Teacher();
            return View(teacher);
        }
        [HttpPost]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            teacherRepository.Create(teacher);
            teacherRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateHomework()
        {
            Homework homework = new Homework();
            return View(homework);
        }
        [HttpPost]
        public IActionResult CreateHomework(Homework homework)
        {
            homeworkRepository.Create(homework);
            homeworkRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateLecGroup()
        {
            LecGroup lecGroup = new LecGroup();
            return View(lecGroup);
        }
        [HttpPost]
        public IActionResult CreateLecGroup(LecGroup lecGroup)
        {
            lecGroupRepository.Create(lecGroup);
            lecGroupRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateLection()
        {
            Lection lection = new Lection();
            return View(lection);
        }
        [HttpPost]
        public IActionResult CreateLection(Lection lection)
        {
            lectionRepository.Create(lection);
            lectionRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            studentRepository.Create(student);
            studentRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateVisitJournal()
        {
            VisitJournal visitJournal = new VisitJournal();
            return View(visitJournal);
        }
        [HttpPost]
        public IActionResult CreateVisitJournal(VisitJournal visitJournal)
        {
            visitJournalRepository.Create(visitJournal);
            visitJournalRepository.Save();
            return RedirectToAction("Index");
        }



        //-----------------УДАЛЕНИЕ ОБЪЕКТОВ----------------------------


    }
}