<%@ Page Title="" Language="C#" MasterPageFile="~/headofdepartment/CRUD.Master" AutoEventWireup="true" CodeBehind="CRUD1.aspx.cs" Inherits="MajorProject.headofdepartment.CRUD1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:GridView  Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"  PagerSettings-PageButtonCount="50" ID="gv" AllowPaging="true" PageSize="25" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">                     
    </asp:GridView>                          <asp:Button ID="updateaccess" Text="Update"  runat="server" OnClick="updateaccess_Click" />
                      </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <asp:GridView  Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"  PagerSettings-PageButtonCount="50" ID="GridView1" AllowPaging="true" PageSize="25" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">
                      <Columns>
                    <asp:CommandField  ShowEditButton="true" />
                          </Columns>
    </asp:GridView>                          <asp:Button ID="Button1" Text="Update"  runat="server" onclick="updateaccess_Click" />
                      </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
  <asp:GridView  Width="100%"  OnPageIndexChanging="GridView1_PageIndexChanging"  PagerSettings-PageButtonCount="50" ID="GridView2" AllowPaging="true" PageSize="25" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">
                      <Columns>
                    <asp:CommandField  ShowEditButton="true" />
                          </Columns>
    </asp:GridView>                          <asp:Button ID="Button2" Text="Update"  runat="server" onclick="updateaccess_Click" />
                      </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
          <script type="text/javascript">  
            // for check all checkbox  
            function CheckAll(Checkbox) {
                var GridVwHeaderCheckbox = document.getElementById("<%=gv.ClientID %>");
                for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                    GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
                }
            }
          </script>  
</asp:Content>