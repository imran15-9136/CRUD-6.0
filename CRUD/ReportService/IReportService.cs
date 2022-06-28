namespace CRUD.ReportService
{
    public interface IReportService
    {
        public byte[] GenerateReportAsync(string reportName, string reporType);
        public byte[] ReportView();
    }
}
