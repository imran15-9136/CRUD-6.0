using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WebForms;


namespace CRUD.Configuration.Library
{
    public class ReportBuilder
    {
        public static ReportViewer GetReportViewer(string reportPath, IEnumerable<ReportDataSource> dataSources, IEnumerable<ReportParameter> reportParameters = null)
        {
            if (dataSources == null || !dataSources.Any())
            {
                throw new Exception("You must provide data source while trying to build report viewer instance");
            }

            ReportViewer reportViewer = new ReportViewer()
            {
                KeepSessionAlive = true,
                SizeToReportContent = true,
                //Width
                ProcessingMode = ProcessingMode.Local
            };
            reportViewer.LocalReport.ReportPath = reportPath;

            foreach (var reportDataSource in dataSources)
            {
                reportViewer.LocalReport.DataSources.Add(reportDataSource);
            }

            if (reportParameters != null && reportParameters.Any())
            {
                reportViewer.LocalReport.SetParameters(reportParameters);
            }

            return reportViewer;
        }

        public static byte[] GetBytesArray(ReportViewer reportViewer)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extensions;
            var bytes = reportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extensions, out streamids, out warnings);
            return bytes;
        }
    }
}
