using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
    public interface IVisitJournalRepository : IRepository<VisitJournal>
    {
        void CheckAbsence();  // проверка прогулов
        void CheckMarks();
    }
}
