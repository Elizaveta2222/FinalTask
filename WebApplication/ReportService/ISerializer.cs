using BusinessLogic.Models;

namespace WebApplicationFinalTask.ReportService
{
    public interface ISerializer
    {
        public string Serialize(IEnumerable<VisitJournal> lectionJournal);
    }
}
