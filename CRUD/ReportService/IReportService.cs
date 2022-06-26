namespace CRUD.ReportService
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName, string reporType);
    }
}
