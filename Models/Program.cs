using Models;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("Добавление");
    Lection lection = new Lection {  Subject = "ndjjjjj"};
    Student student1 = new Student { Name = "Костя", Surname = "ggggg"};
    VisitJournal visit = new VisitJournal { };
    LecGroup lecGroup = new LecGroup { Number = "3333"};
    db.VisitJournals.Add(visit); 
    db.Students.AddRange(student1);    
    db.Lections.AddRange(lection);



    db.SaveChanges();


    lecGroup.Students.Add(student1);
    // добавление группам курсов


    foreach (var student in db.Students.ToList())
    {
        Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
        Console.WriteLine($"Группа изучает:");
        foreach (var course in student.Group?.Courses)
        {
            Console.WriteLine(course.Name);
        }
    }
    // удаление первого студента
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Удаление");
    Student? st = db.Students.FirstOrDefault();
    if (st != null)
    {
        db.Students.Remove(st);
        db.SaveChanges();
        foreach (var student in db.Students.ToList())
        {
            Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
            Console.WriteLine($"Группа изучает:");
            foreach (var course in student.Group?.Courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Редактирование");
    st = db.Students.FirstOrDefault();
    if (st != null)
    {
        st.Name = "Пётр";
        db.SaveChanges();
        foreach (var student in db.Students.ToList())
        {
            Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
            Console.WriteLine($"Группа изучает:");
            foreach (var course in student.Group?.Courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}

