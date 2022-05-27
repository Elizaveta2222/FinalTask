using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface ILectionRepository : IRepository<Lection> 
    {
        IEnumerable<Lection> GetObjectList(); // получение всех объектов
        Lection GetObject(int id); // получение одного объекта по id
        void Create(Lection item); // создание объекта
        void Update(Lection item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
