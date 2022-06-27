using AspNetCore.Reporting;
using Models.Responses;
using System.Reflection;
using System.Text;

namespace CRUD.ReportService
{
    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(string reportName, string reporType)
        {
            
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("CRUD.dll",string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            List<ItemCategoryReturnDto> catagoryList = new List<ItemCategoryReturnDto>();

            var cata1 = new ItemCategoryReturnDto { Id = 1, Name = "Food"};
            var cata2 = new ItemCategoryReturnDto { Id = 2, Name = "Technology" };
            var cata3 = new ItemCategoryReturnDto { Id = 3, Name = "Cosmatics" };
            var cata4 = new ItemCategoryReturnDto { Id = 4, Name = "Equipment" };
            var cata5 = new ItemCategoryReturnDto { Id = 5, Name = "Arams" };

            catagoryList.Add(cata1);
            catagoryList.Add(cata2);
            catagoryList.Add(cata3);
            catagoryList.Add(cata4);
            catagoryList.Add(cata5);

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
    }
}
