/*using Microsoft.AspNetCore.Mvc;
using WebApplicationFinalTask.ReportService;
using System.IO;
using BusinessLogic.Models;
using WebApplicationFinalTask.Models;

namespace WebApplicationFinalTask.Report
{
    public class ReportService
    {
        private IEnumerable<VisitJournal> GetLectionJournal(int lectionId)
        {
            VisitJournalRepository vjr = new VisitJournalRepository();
            return vjr.GetObjectList().Where(vjInfo => vjInfo.Lection.Id == lectionId);
        }



        public FileResult Report(int lectionId, ISerializer serializer)
        {
            string fileName = "your file name";



            string fileBytes = serializer.Serialize(GetLectionJournal(lectionId));

            return File(fileBytes, "application/force-download", fileName);
        }
    }
}
*/