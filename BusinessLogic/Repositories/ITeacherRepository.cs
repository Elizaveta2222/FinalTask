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

    }
}
