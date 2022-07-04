namespace CRUD.ReportService
{
    public interface IReportServices
    {
        public byte[] GenerateReportAsync(string reportName, string reporType);
        public byte[] ReportView();
    }
}
