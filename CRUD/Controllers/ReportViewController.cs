using CRUD.ReportService;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    
    public class ReportViewController : Controller
    {
        private readonly IReportServices _reportService;
        public ReportViewController(IReportServices _reportService)
        {
            this._reportService = _reportService;
        }
        public IActionResult ReportView()
        {
            var result = _reportService.ReportView();
            return File(result, "applicaiton/pdf");
        }
    }
}
