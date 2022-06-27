using AspNetCore.Reporting;
using CRUD.Configuration.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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

        [HttpGet]
        [Route("MyReport")]
        public IActionResult GetReport()
        {
            var reportViewer = new ReportViewer { ProcessingMode = ProcessingMode.Local };
            reportViewer.LocalReport.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\ReportFiles\\Report1.rdlc";

            //var dataSource = "Select * From Employee List";
            //var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFiles\\Report1.rdlc";


            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("NameOfDataSource1", reportObjectList1));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("NameOfDataSource2", reportObjectList1));

            //var reportDataSources = new[]
            //{
            //    new ReportDataSource("DS_ItemList", reportData.ToList()),
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
    }
}
