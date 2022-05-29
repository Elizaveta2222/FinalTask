using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var lections = lectionRepository.GetObjectList();
            return View(lections);
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
            teacherRepository.Update(teacher);
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
            homeworkRepository.Update(homework);
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
            lecGroupRepository.Update(lecGroup);
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
            lectionRepository.Update(lection);
            lectionRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            Student student = new Student();
            ViewBag.LecGroups = new SelectList(lecGroupRepository.GetObjectList(), "Id", "Number");
            return View(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.LecGroup = db.LecGroups.Where(a => a.Id == student.LecGroup.Id).FirstOrDefault();
            student.LecGroupId=student.LecGroup.Id;
            studentRepository.Update(student);
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
            visitJournalRepository.Update(visitJournal);
            visitJournalRepository.Save();
            return RedirectToAction("Index");
        }



        //-----------------УДАЛЕНИЕ ОБЪЕКТОВ----------------------------

        [HttpGet]
        public IActionResult DeleteHomework(Homework homework)
        {
            homeworkRepository.Delete(homework.Id);
            homeworkRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteLecGroup(LecGroup lecGroup)
        {
            lecGroupRepository.Delete(lecGroup.Id);
            lecGroupRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteLection(Lection lection)
        {
            lectionRepository.Delete(lection.Id);
            lectionRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteStudent(Student student)
        {
            studentRepository.Delete(student.Id);
            studentRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteTeacher(Teacher teacher)
        {
            teacherRepository.Delete(teacher.Id);
            teacherRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteVisitJournal(VisitJournal visitJournal)
        {
            visitJournalRepository.Delete(visitJournal.Id);
            visitJournalRepository.Save();
            return RedirectToAction("Index");
        }



        //-----------------ОБНОВЛЕНИЕ ОБЪЕКТОВ----------------------------

        [HttpGet]
        public IActionResult UpdateHomework(Homework homework)
        {
            return View("CreateHomework", homework);
        }
        [HttpGet]
        public IActionResult UpdateLecGroup(LecGroup lecGroup)
        {
            return View("CreateLecGroup", lecGroup);
        }
        [HttpGet]
        public IActionResult UpdateLection(Lection lection)
        {
            return View("CreateLection", lection);
        }
        [HttpGet]
        public IActionResult UpdateStudent(Student student)
        {
            return View("CreateStudent", student);
        }
        [HttpGet]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            return View("CreateTeacher", teacher);
        }
        [HttpGet]
        public IActionResult UpdateVisitJournal(VisitJournal visitJournal)
        {
            return View("CreateVisitJournal", visitJournal);
        }


        //----------------------------------------------------------------------------------------

        public IActionResult Students()
        {
            var students = studentRepository.GetObjectList();
            return View(students);
        }
        public IActionResult LecGroups()
        {
            var lecgroup = lecGroupRepository.GetObjectList();
            return View(lecgroup);
        }
        public IActionResult Teachers()
        {
            var teacher = teacherRepository.GetObjectList();
            return View(teacher);
        }
    }
}