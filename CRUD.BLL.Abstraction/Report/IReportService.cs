namespace CRUD.BLL.Abstraction.Report
{
    public interface IReportService
    {
        public Task<byte[]> GenerateReportAsync(string reportName, string reporType);
        public byte[] ReportView();
    }
}
