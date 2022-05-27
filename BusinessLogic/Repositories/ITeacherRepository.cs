using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface ITeacherRepository: IRepository<Student>, IObserver<string>
    {
        void Update(string data); //получение данных от издателя
        IEnumerable<Teacher> GetObjectList(); // получение всех объектов
        Teacher GetObject(int id); // получение одного объекта по id
        void Create(Teacher item); // создание объекта
        void Update(Teacher item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
