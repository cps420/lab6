<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab6.App_Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#009900">
                <asp:Label ID="Label1" runat="server" Text="Student ID:"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Dropdown" />
                <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
                <asp:Button ID="BtnInsert" runat="server" Text="Insert" OnClick="BtnInsert_Click" />
                <asp:Button ID="BtnEdit" runat="server" Text="Edit" OnClick="BtnEdit_Click" />
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" BackColor="#99CCFF">
                <p>Student ID:</p>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                <p>Student Name:</p>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <asp:CheckBox ID="chkScholar" runat="server" Text="Scholar" />

            </asp:Panel>
        </div>
    </form>
</body>
</html>
