using AspNetCore.Reporting;
using CRUD.Configuration.Library;
using CRUD.ReportService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using System.Net.Mime;
using AspNetCore.Reporting;
using System.Reflection;
using Models.Responses;


namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IReportService reportService;
        public ReportController(IWebHostEnvironment webHostEnvironment, IReportService reportService)
        {
            _webHostEnvironment = webHostEnvironment;
            this.reportService = reportService;
        }



        //public IActionResult Index()
        //{
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFiles\\EmployeeListReport.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rp1", "Welcome to Codebehind");
        //    LocalReport localReport = new LocalReport(path);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "applicaiton/pdf");

        //}

        //public IActionResult GetEmployeeList()
        //{
        //    var reportData = _db.VW_Items.AsQueryable();


        //    if (model.ItemTypeId != null && model.ItemTypeId > 0)
        //    {
        //        reportData = reportData.Where(c => c.ItemTypeId == model.ItemTypeId);
        //    }

        //    if (model.ItemId != null && model.ItemId > 0)
        //    {
        //        reportData = reportData.Where(c => c.ItemId == model.ItemId);
        //    }

        //    reportData = reportData.OrderBy(c => c.ItemCreateDate);

        //    var reportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\Item\ItemList.rdlc";
        //    var reportDataSources = new[]
        //    {
        //        new ReportDataSource("DS_ItemList", reportData.ToList()),
        //    };

        //    var reportParameters = new[]
        //    {
        //        new ReportParameter("ItemType", model.ItemTypeName)
        //    };

        //    ReportViewer reportViewer = ReportBuilder.GetReportViewer(reportPath, reportDataSources, reportParameters);

        //    var bytes = ReportBuilder.GetBytesArray(reportViewer);
        //    return File(bytes, "application/pdf");
        //}

        [HttpGet("MyReport")]
        public IActionResult GetReport()
        {
            var reportViewer = new ReportViewer { ProcessingMode = ProcessingMode.Local };
            //reportViewer.LocalReport.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\ReportFiles\\Report1.rdlc";

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CRUD.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\Report1.rdlc", fileDirPath);



            List<ItemCategoryReturnDto> catagoryList = new List<ItemCategoryReturnDto>();

            var cata1 = new ItemCategoryReturnDto { Id = 1, Name = "Food" };
            var cata2 = new ItemCategoryReturnDto { Id = 2, Name = "Technology" };
            var cata3 = new ItemCategoryReturnDto { Id = 3, Name = "Cosmatics" };
            var cata4 = new ItemCategoryReturnDto { Id = 4, Name = "Equipment" };
            var cata5 = new ItemCategoryReturnDto { Id = 5, Name = "Arams" };

            catagoryList.Add(cata1);
            catagoryList.Add(cata2);
            catagoryList.Add(cata3);
            catagoryList.Add(cata4);
            catagoryList.Add(cata5);




            //var dataSource = "Select * From Employee List";
            //var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFiles\\Report1.rdlc";


            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("NameOfDataSource1", catagoryList.AsEnumerable));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("NameOfDataSource2", reportObjectList1));

            //var reportDataSources = new[]
            //{
            //    new ReportDataSource("DS_ItemList", catagoryList.ToList()),
            //};

            //var reportParameters = new[]
            //{
            //    new ReportParameter("rp1","Code Behind Ltd.")
            //};

            //ReportViewer reportViewer1 = ReportBuilder.GetReportViewer(path, dataSource, reportParameters);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            var bytes = reportViewer.LocalReport.Render("application/pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);

            return File(bytes, "application/pdf");
        }


        [HttpGet("{reportName}/reportType")]
        public IActionResult Get(string reportName, string reportType)
        {
            var reportFileByteString = reportService.GenerateReportAsync(reportName, reportType);
            return File(reportFileByteString, MediaTypeNames.Application.Octet, GetReportName(reportName, reportType));
        }

        private string GetReportName(string reportName, string reportType)
        {
            var outputFileName = reportName + ".pdf";

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    outputFileName = reportName + ".pdf";
                    break;
                case "XLS":
                    outputFileName = reportName + ".xls";
                    break;
                case "WORD":
                    outputFileName = reportName + ".doc";
                    break;
            }

            return outputFileName;
        }

        [HttpGet("ReportView")]
        public ActionResult ReportView()
        {
            var result = reportService.ReportView();
            return File(result, "applicaiton/pdf");
        }
    }
}
