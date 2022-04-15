using System;

namespace DepartmentWebForms.Forms
{
    public partial class AddDepartmentForm : System.Web.UI.Page
    {
        DepartmentServiceReference.DepartmentServiceClient client = new DepartmentServiceReference.DepartmentServiceClient();
        int departmentId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            departmentId = Convert.ToInt32(Session["departmentId"]);
            if (departmentId > 0 && Session["isEdit"] != null && Session["isEdit"].ToString() == "True")
            {
                txtDepartmentCode.Text = Request.QueryString["code"];
                txtDepartmentName.Text = Request.QueryString["name"];
                chkActive.Checked = Convert.ToInt32(Request.QueryString["active"]) == 0 ? false : true;
                Session["isEdit"] = "False";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentServiceReference.DeparmentDetails departmentDetail = new DepartmentServiceReference.DeparmentDetails();
                departmentDetail.DepartmentId = departmentId;
                departmentDetail.DepartmentCode = txtDepartmentCode.Text;
                departmentDetail.DepartmentName = txtDepartmentName.Text;
                departmentDetail.IsActive = chkActive.Checked == true ? 1 : 0;
                string message = client.InsertORUpdateDepartmentDetails(departmentDetail);
                if (message.Contains("already"))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = message;
                }
                else
                {
                    lblMessage.Visible = false;
                    Response.Redirect("~/Forms/DepartmentListForm.aspx");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDepartmentCode.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            lblMessage.Visible = false;
        }
    }
}