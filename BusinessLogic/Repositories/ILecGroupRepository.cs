using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface ILecGroupRepository : IRepository<LecGroup>
    {
        IEnumerable<LecGroup> GetObjectList(); // получение всех объектов
        LecGroup GetObject(int id); // получение одного объекта по id
        void Create(LecGroup item); // создание объекта
        void Update(LecGroup item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
