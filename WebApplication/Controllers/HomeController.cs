using BusinessLogic.Models;
using BusinessLogic.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationFinalTask.Models;

namespace WebApplicationFinalTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;
        HomeworkRepository homeworkRepository = new HomeworkRepository();
        LecGroupRepository lecGroupRepository = new LecGroupRepository();
        LectionRepository lectionRepository = new LectionRepository();
        StudentRepository studentRepository = new StudentRepository();
        TeacherRepository teacherRepository = new TeacherRepository();
        IVisitJournalRepository visitJournalRepository;

        public HomeController(ApplicationContext applicationContext, IVisitJournalRepository visitJournalRepository)
        {
            db = applicationContext;
            this.visitJournalRepository = visitJournalRepository;
        } 

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
            return RedirectToAction("Teachers");
        }
        [HttpGet]
        public IActionResult CreateHomework()
        {
            Homework homework = new Homework();
            ViewBag.Lections = new SelectList(lectionRepository.GetObjectList(), "Id", "Id");
            return View(homework);
        }
        [HttpPost]
        public IActionResult CreateHomework(Homework homework)
        {
            homework.Lection = db.Lections.Where(a => a.Id == homework.Lection.Id).FirstOrDefault();
            homeworkRepository.Update(homework);
            homeworkRepository.Save();
            return RedirectToAction("Homework");
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
            return RedirectToAction("LecGroups");
        }
        [HttpGet]
        public IActionResult CreateLection()
        {
            Lection lection = new Lection();
            ViewBag.Teachers = new SelectList(teacherRepository.GetObjectList(), "Id", "Surname");
            return View(lection);
        }
        [HttpPost]
        public IActionResult CreateLection(Lection lection)
        {
            lection.Teacher= db.Teachers.Where(a => a.Id == lection.Teacher.Id).FirstOrDefault();
            lection.TeacherId=lection.Teacher.Id;
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
            return RedirectToAction("Students");
        }
        [HttpGet]
        public IActionResult CreateVisitJournal(Lection lection)
        {
            GroupsToLec gl= new GroupsToLec();
            ViewBag.Lection = lection;
            ViewBag.LecGroups = new SelectList(lecGroupRepository.GetObjectList(), "Id", "Number");
            return View("CreateVisitJournal", gl);
        }
        [HttpPost]
        public IActionResult CreateVisitJournal(GroupsToLec lecGroup)
        {
            var students=db.Students.Where(s=>s.LecGroupId==lecGroup.GroupId).ToList();
            foreach(var student in students)
            {
                VisitJournal vj=new VisitJournal();
                vj.Mark = VisitJournal.Marks.Absence;
                vj.Student= db.Students.Where(s=>s.Id==student.Id).Include(s=>s.LecGroup).First();
                vj.Lection = db.Lections.Where(l=>l.Id==lecGroup.LectionId).Include(l=>l.Teacher).First();
                visitJournalRepository.Create(vj);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeJournal(Lection lection)
        {
            var lec = lection;
            List<VisitJournal> vjs=db.VisitJournals.Include(vj=>vj.Lection).Include(vj=>vj.Student).Where(vj=>vj.Lection.Id==lection.Id).ToList();
            return View(vjs);
        }
        [HttpPost]
        public IActionResult ChangeJournal(List<VisitJournal> vjs)
        {
            foreach(VisitJournal vj in vjs)
            {
                visitJournalRepository.Update(vj);
            }
            visitJournalRepository.Save();

            return RedirectToAction("VisitJournals");
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
            var homeworks=db.Homeworks.Where(h=>h.Lection.Id==lection.Id).ToList();
            foreach(var homework in homeworks)
            {
                homeworkRepository.Delete(homework.Id);
            }
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
            var lections=db.Lections.Where(l=>l.Teacher.Id==teacher.Id).ToList();
            foreach (var lection in lections)
            {
                lectionRepository.Delete(lection.Id);
            }
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
            ViewBag.Lections = new SelectList(lectionRepository.GetObjectList(), "Id", "Id");
            homework = db.Homeworks.Where(s => s.Id == homework.Id).First();
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
            ViewBag.Teachers = new SelectList(teacherRepository.GetObjectList(), "Id", "Surname");
            lection=db.Lections.Where(l=>l.Id==lection.Id).First();
            return View("CreateLection", lection);
        }
        [HttpGet]
        public IActionResult UpdateStudent(Student student)
        {
            ViewBag.LecGroups = new SelectList(lecGroupRepository.GetObjectList(), "Id", "Number");
            student=db.Students.Where(s=>s.Id == student.Id).First();
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
        public IActionResult Homework()
        {
            var homework = homeworkRepository.GetObjectList();
            return View(homework);
        }
        public IActionResult VisitJournals()
        {
            var vjs = visitJournalRepository.GetObjectList();
            return View(vjs);
        }
    }
}