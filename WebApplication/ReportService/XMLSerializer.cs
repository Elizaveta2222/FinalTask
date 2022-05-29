using BusinessLogic.Models;
using System.Xml;
using System.Xml.Serialization;
using WebApplicationFinalTask.Report;

namespace WebApplicationFinalTask.ReportService
{
    public class XMLSerializer : ISerializer
    {
        public string Serialize(IEnumerable<VisitJournal> lectionJournal)
        {
            if (lectionJournal == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(IEnumerable<VisitJournal>));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, lectionJournal);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
    }
}
