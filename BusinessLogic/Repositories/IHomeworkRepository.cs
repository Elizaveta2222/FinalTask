using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface IHomeworkRepository : IRepository<Homework>
    {
        IEnumerable<Homework> GetObjectList(); // получение всех объектов
        Homework GetObject(int id); // получение одного объекта по id
        void Create(Homework item); // создание объекта
        void Update(Homework item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
