<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gaurd.aspx.cs" Inherits="MajorProject.gaurd.gaurd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../shared/history.css" rel="stylesheet" />

     <script type="text/javascript">  
// for check all checkbox  
        function CheckAll(Checkbox) {  
            var GridVwHeaderCheckbox = document.getElementById("<%=gv.ClientID %>");  
            for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {  
                GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;  
            }  
        }  
     </script>  
</head>
<body>
    <div >
     <div class="navbar">
        <image src="/images/1.jpg" runat="server" id="img" style="margin-top:10%;" width="80%" height="250px"></image>
    <asp:Label ID="Name" runat="server" Height="30px" Text=""></asp:Label>
  <div  style="height:450px; ">
  <a href="gaurd.aspx?q=updatedeparturestudent" id="updatedeparturestudent" runat="server"><i class="fa fa-fw fa-update"></i> Update Student Departure</a>
  <a href="gaurd.aspx?q=updatedepartureprofessor" id="updatedepartureprofessor" runat="server"><i class="fa fa-fw fa-update"></i> Update Professor departure</a>
  <a href="gaurd.aspx?q=updatearrivalstudent" id="updatearrivalstudent" runat="server"><i class="fa fa-fw fa-update"></i> Update Student arrival </a>
  <a href="gaurd.aspx?q=updatearrivalprofessor" id="updatearrivalprofessor" runat="server"><i class="fa fa-fw fa-update"></i> Update Professor arrival </a>
  <a href="../shared/Logout.aspx" onclick="return confirm('Are you sure?')"   ><i class="fa fa-fw fa-user"></i> Logout</a>
</div>
         </div>
        <div id="mdv" >

         <div class="body1">        
    <div class="container">

          <div id="dgv">
                    <form runat="server">
                        <table id="mt"><tr>
                                      <td>
                <asp:Label runat="server" ID="prnlbl" Text="PRN"></asp:Label><asp:TextBox AutoPostBack="true" ID="tb" OnTextChanged="ddr2_TextChanged"  runat="server" Text="" MaxLength="16" ></asp:TextBox>
                </td>                
                <td>
                <asp:Label runat="server" ID="departmentlbl" Text="college"></asp:Label><asp:DropDownList  AutoPostBack="true" OnSelectedIndexChanged="ddr2_TextChanged" DataTextField="name" DataValueField="name" AppendDataBoundItems="true"   ID="ddr" runat="server">
                        <asp:ListItem Text="Please select" Value="" />

                               </asp:DropDownList>                 
                </td>
                            <td><asp:Label runat="server" ID="divisionlbl" Text="department"></asp:Label><asp:DropDownList  AutoPostBack="true"  ID="ddr2" OnSelectedIndexChanged="ddr3_TextChanged"  runat="server" DataTextField="name" DataValueField="name" AppendDataBoundItems="false">
                                                                <asp:ListItem  Text="Please Select" Value="Please Select" />
                       </asp:DropDownList>  
</td>
<td>
                    <asp:Label runat="server" ID="semlbl" Text="sem"></asp:Label> <asp:DropDownList OnSelectedIndexChanged="ddr4_TextChanged"  AutoPostBack="true"   ID="ddr3" runat="server" DataTextField="sem" DataValueField="sem" AppendDataBoundItems="false">
                                                            <asp:ListItem Text="0" Value="0" />
                                  </asp:DropDownList>  
</td>
<td>                    <asp:Button ID="btn"  OnClick="clearSelections" Text="Clear Selections" runat="server"/>
</td></tr></table>
                 <asp:GridView  Width="100%"  OnPageIndexChanging="GridView1_PageIndexChanging"  ID="gv" AllowPaging="true" PageSize="15" PagerSettings-PageButtonCount="50" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">
                     <Columns>
                         <asp:TemplateField HeaderText="Select">  
                   <HeaderTemplate  >
                       <asp:CheckBox runat="server"  onclick="CheckAll(this);" /> 
                   </HeaderTemplate> 
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server"  />  
                    </ItemTemplate>  
                </asp:TemplateField> 
                     </Columns>
    </asp:GridView>  
    <asp:Button Font-Bold="true" BorderColor="Black" ID="update" Text="Update"  runat="server" OnClick="updatetime" />
                        </form>
</div>
        </div>
            </div>
              
        </div>
        </div>
</body>
</html>

