<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepartmentForm.aspx.cs" Inherits="DepartmentWebForms.Forms.AddDepartmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Add Department Page</h2>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;
            <asp:Label ID="lblDepartmentCode" runat="server" Text="Department Code :"></asp:Label>
&nbsp;<asp:TextBox ID="txtDepartmentCode" runat="server" Height="27px" style="margin-left: 33px; margin-top: 31px" Width="208px" autocomplete="off"></asp:TextBox>
            <br />
            <asp:Label ID="lblMessage" runat="server" style="margin-left: 171px; margin-bottom: 100px" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp; <asp:Label ID="lblDepartmentName" runat="server" Text="Department Name :"></asp:Label>
            <asp:TextBox ID="txtDepartmentName" runat="server" Height="27px" style="margin-left: 33px" Width="205px" autocomplete="off"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:CheckBox ID="chkActive" runat="server" Text="  Active" style="margin-left: 170px" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Height="35px" style="margin-left: 168px" Text="Submit" Width="84px" OnClick="btnSubmit_Click" BackColor="#FF0066" ForeColor="White" />
            <asp:Button ID="btnReset" runat="server" Height="34px" style="margin-left: 21px" Text="Reset" Width="90px" OnClick="btnReset_Click" BackColor="#FF0066" ForeColor="White" />
        </div>
    </form>
</body>
</html>
