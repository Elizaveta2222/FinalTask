using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    interface IVisitJournalRepository : IRepository<VisitJournal>, IObservable<string>
    {
        void CheckAbsence();  // проверка прогулов
    }
}
