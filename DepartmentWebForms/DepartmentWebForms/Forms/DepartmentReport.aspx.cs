using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentWebForms.Forms
{
    public partial class DepartmentReport : System.Web.UI.Page
    {
        DepartmentServiceReference.DepartmentServiceClient client = new DepartmentServiceReference.DepartmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DepartmentReport.rdlc");
                ReportDataSource departments = new ReportDataSource("departments", client.GetDepartments());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(departments);
            }
        }
    }
}