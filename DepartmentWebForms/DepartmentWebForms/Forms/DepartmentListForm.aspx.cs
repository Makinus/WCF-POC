using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentWebForms.Scripts
{
    public partial class DepartmentListForm : System.Web.UI.Page
    {
        DepartmentServiceReference.DepartmentServiceClient client = new DepartmentServiceReference.DepartmentServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["departmentId"] = 0;
                ViewState["Paging"] = client.GetDepartments();
                dgvDepartment.DataSource = client.GetDepartments();
                dgvDepartment.DataBind();
            }
        }

        protected void btn_AddDepartment(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/AddDepartmentForm.aspx");
        }

        protected void DgvDepartment_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Edit") return;
            LinkButton commandSource = e.CommandSource as LinkButton;
            string code = Convert.ToString(commandSource.CommandArgument);
            DepartmentServiceReference.DeparmentDetails departmentDetail = client.GetDepartmentByID(code);
            Session["departmentId"] = departmentDetail.DepartmentId;
            Session["isEdit"] = "True";
            Response.Redirect("~/Forms/AddDepartmentForm.aspx?active=" + departmentDetail.IsActive + "&code=" + departmentDetail.DepartmentCode + "&name=" + departmentDetail.DepartmentName);
        }

        protected void DgvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDepartment.PageIndex = e.NewPageIndex;
            dgvDepartment.DataSource = ViewState["Paging"];
            dgvDepartment.DataBind();
            txtSearch.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            dgvDepartment.DataSource = null;
            dgvDepartment.DataSource = client.GetDepartmentBySearch(searchValue);
            dgvDepartment.DataBind();
        }

        protected void Export_Excel(object sender, ImageClickEventArgs e)
        {
            try 
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                ReportViewer viewer = new ReportViewer();
                ReportDataSource datasource = new ReportDataSource("departments", client.GetDepartments());
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(datasource);
                viewer.ZoomMode = ZoomMode.PageWidth;
                viewer.LocalReport.ReportPath = Server.MapPath("~/Reports/DepartmentReport.rdlc");

                byte[] bytes = viewer.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename= DepartmentReport." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
            // Response.Redirect("~/Forms/DepartmentReport.aspx");
        }
    }
}