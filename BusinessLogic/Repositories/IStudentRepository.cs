using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface IStudentRepository: IRepository<Student>, IObserver<string>
    {
        void Update(string data); //получение данных от издателя
        IEnumerable<Student> GetObjectList(); // получение всех объектов
        Student GetObject(int id); // получение одного объекта по id
        void Create(Student item); // создание объекта
        void Update(Student item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
