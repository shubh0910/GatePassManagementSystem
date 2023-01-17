<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="MajorProject.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>temp</title> 
</head>
<body>
    <form runat="server">
<asp:GridView ID="gvCustomers"  runat="server" AutoGenerateColumns="false" OnRowEditing="EditCustomer"
   OnRowDataBound="RowDataBound" >
    <Columns>
        <asp:TemplateField HeaderText="City">
            <ItemTemplate>
                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("name")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlCities" runat="server">
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>
        </form>
</body>
</html>

