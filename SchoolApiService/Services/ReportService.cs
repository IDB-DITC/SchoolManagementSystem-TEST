using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using SchoolApp.DAL.SchoolContext;

namespace SchoolApiService.Services
{
    public class ReportService
    {
        private readonly IWebHostEnvironment _webHost;

        public ReportService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public string GenerateReport(string path, Dictionary<string, object> parameters = default!)
        {
            try
            {
                WebReport webReport = new WebReport();

                webReport.Report.Load( @$"{_webHost.ContentRootPath}\Reports\{path}");

                MsSqlDataConnection sqlConnection = new MsSqlDataConnection();


                sqlConnection.ConnectionString = "Server=(localdb)\\mssqllocaldb; Database=SchoolSystemDb; Trusted_Connection=True;";


                webReport.Report.SetParameterValue("dbCon", sqlConnection.ConnectionString);


                foreach (var item in parameters)
                {
                    webReport.Report.SetParameterValue(item.Key, item.Value);
                }



                webReport.Report.Prepare();


                PDFSimpleExport export = new PDFSimpleExport();
                string pdf;
                byte[] pdfBytes;
                MemoryStream ms = new MemoryStream();

                webReport.Report.Export(export, ms);
                ms.Position = 0;
                pdfBytes = ms.ToArray();

                pdf = Convert.ToBase64String(pdfBytes);
                return pdf;
            }
            catch (Exception ex)
            {
                throw;
                
            }
        }


    }
}
