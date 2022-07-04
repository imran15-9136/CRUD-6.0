using AspNetCore.Reporting;
using CRUD.BLL.Abstraction.Report;
using CRUD.Repository.Abstraction.Category;
using Models.Responses;
using System.Reflection;
using System.Text;


namespace CRUD.BLL.Report
{
    public class ReportService : IReportService
    {
        private readonly ICategoryRepository _categoryRepository;
        public ReportService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<byte[]> GenerateReportAsync(string reportName, string reporType)
        {
            
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CRUD.BLL.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            var catagoryList = await _categoryRepository.GetAllAsync();

            //List<ItemCategoryReturnDto> catagoryList = new List<ItemCategoryReturnDto>();

            //var cata1 = new ItemCategoryReturnDto { Id = 1, Name = "Food"};
            //var cata2 = new ItemCategoryReturnDto { Id = 2, Name = "Technology" };
            //var cata3 = new ItemCategoryReturnDto { Id = 3, Name = "Cosmatics" };
            //var cata4 = new ItemCategoryReturnDto { Id = 4, Name = "Equipment" };
            //var cata5 = new ItemCategoryReturnDto { Id = 5, Name = "Arams" };

            //catagoryList.Add(cata1);
            //catagoryList.Add(cata2);
            //catagoryList.Add(cata3);
            //catagoryList.Add(cata4);
            //catagoryList.Add(cata5);

            report.AddDataSource("DSCategory", catagoryList);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRendertype(reporType), 1, parameters);

            return result.MainStream;
        }


        private RenderType GetRendertype(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }

        public byte[] ReportView()
        {
            string mimtype = "";
            int pageIndex = 1;
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CRUD.BLL.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\Report1.rdlc", fileDirPath);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("rp1", "Welcome to Codebehind");
            LocalReport report = new LocalReport(rdlcFilePath);

            //List<ItemCategoryReturnDto> catagoryList = new List<ItemCategoryReturnDto>();

            //var cata1 = new ItemCategoryReturnDto { Id = 1, Name = "Food" };
            //var cata2 = new ItemCategoryReturnDto { Id = 2, Name = "Technology" };
            //var cata3 = new ItemCategoryReturnDto { Id = 3, Name = "Cosmatics" };
            //var cata4 = new ItemCategoryReturnDto { Id = 4, Name = "Equipment" };
            //var cata5 = new ItemCategoryReturnDto { Id = 5, Name = "Arams" };

            //catagoryList.Add(cata1);
            //catagoryList.Add(cata2);
            //catagoryList.Add(cata3);
            //catagoryList.Add(cata4);
            //catagoryList.Add(cata5);

            var catagoryList = _categoryRepository.GetAllAsync();

            report.AddDataSource("DSCategory", catagoryList);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            var result = report.Execute(RenderType.Pdf, pageIndex, parameters, mimtype);
            return result.MainStream;
           // return File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,"");

        }
    }


}
