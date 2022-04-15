<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentListForm.aspx.cs" Inherits="DepartmentWebForms.Scripts.DepartmentListForm" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .clslnkbutton {
            max-height: 27px;
            image-rendering: pixelated;
            margin-left: 14px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <h2>Department List Page</h2>
    <form id="Department" runat="server">
        <asp:TextBox ID="txtSearch" runat="server" Height="26px" Width="371px" placeholder="Enter department code and name" autocomplete="off"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" BackColor="#FF0066" ForeColor="White" Height="32px" style="margin-left: 19px" Text="Search" Width="92px" OnClick="btnSearch_Click" />
        <asp:ImageButton ID="btnExcel" runat="server" CssClass="clslnkbutton" Width="63px" ImageUrl="~/Content/images/excel.png" OnClick="Export_Excel" Height="26px"/>
    <asp:Button ID="addDepartment" runat="server" OnClick="btn_AddDepartment" Text="Add" Height="31px" style="margin-left: 6px" Width="71px" BackColor="#FF0066" ForeColor="White" />
        &nbsp;&nbsp;
        <br />
        <br />
    <asp:GridView ID="dgvDepartment" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="DgvDepartment_PageIndexChanging" PageIndex="5" PageSize="5" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" OnRowCommand="DgvDepartment_OnRowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:BoundField DataField="DepartmentId" HeaderText="Serial No" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
            <HeaderStyle HorizontalAlign="left" />
            </asp:BoundField>
            <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
             <asp:TemplateField ShowHeader="False" HeaderText="Status">
            <ItemTemplate>
                <asp:Label Text='<%# Eval("IsActive").ToString() == "0" ? "Inactive" : "Active" %>'
                    runat="server" style="margin-right: 60px"/>
            </ItemTemplate>
        </asp:TemplateField>
            <asp:TemplateField ShowHeader="False" HeaderText="Action">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit"
                    Text="Edit" CommandArgument='<%# Eval("DepartmentCode") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </form>
</body>
</html>
