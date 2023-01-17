﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateData.aspx.cs" Inherits="MajorProject.headofdepartment.updateData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         @import url("https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css");

         @import url("https://fonts.googleapis.com/css2? family=Muli&display=swap");
         #Name{
    margin-left:10%;
}
       *{
           box-sizing: border-box;

            }

    .body1 {
           font-family: "Muli", sans-serif;
           background-color: #e8e6e7;
           color: #fff;
                  display: flex;
           flex-direction: column;
           align-items: center;
           justify-content: center;
           height: 99.8vh;
           overflow: hidden;
           margin-left:19.55%;
           margin-top:-50.5%;
           margin-right:-.5%;
           margin-bottom:-0.3%;
           font-size:22px;
           }
    .container {
    background-color: #cfb79f;
    padding: 20px 40px;
    border-radius: 5px;
    color: #4c7972;
}
    #fs{
        border-color:black;
        border-width:3px;
    }
     




    .navbar {
  width: 20%;
    height:100%;
    margin-left:-.51%;
    margin-top:-1.025%;
  margin-bottom:0%;
  background-color: #555;
  overflow: auto;
}

/* Navbar links */
.navbar a {
  float: left;
  text-align: center;
  padding: 15px;
  color: white;
  text-decoration: none;
  font-size: 17px;
    width:100%;

}

/* Navbar links on mouse-over */
.navbar a:hover {
  background-color: #000;
}

/* Current/active navbar link */
.active {
  background-color: #04AA6D;
}

/* Add responsiveness - will automatically display the navbar vertically instead of horizontally on screens less than 500 pixels */
@media screen and (max-width: 500px) {
  .navbar a {
    float: none;
    display: block;
  }
}
#img{
    margin-left:10%;
}
#mt{
    border-spacing:0px;
}
   </style>
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

    <div class="navbar">
        <image src="/images/1.jpg" runat="server" id="img" style="margin-top:10%;" width="80%" height="250px"></image>
    <asp:Label ID="Name" runat="server" Height="32px" Text=""></asp:Label>
  <div  style="height:450px; ">
      <a id="home" runat="server" href="headofdepartment.aspx"><i class="fa fa-fw fa-home"></i> Home</a><br />
  <a href="../shared/history.aspx?q=normal"  runat="server" target="_self"><i class="fa fa-fw fa-history"></i>Your History</a>
  <a href="../classcounsellor/history.aspx?q=approvepassstudent"  id="approvepassstudent" runat="server"><i class="fa fa-fw fa-confirm"></i> Approve Student Gatepass</a>
  <a href="../classcounsellor/history.aspx?q=approvepassprofessor"  id="approvepassprofessor" runat="server"><i class="fa fa-fw fa-approve"></i> Approve Professor Gatepass</a>
  <a href="../classcounsellor/history.aspx?q=student" id="student" runat="server" ><i class="fa fa-fw fa-history"></i>Student Gatepass History </a>
  <a href="../classcounsellor/history.aspx?q=professor" id="professor" runat="server" ><i class="fa fa-fw fa-history"></i>Professor Gatepass History </a>
  <a href="updateData.aspx" id="updatestudent" class="active" runat="server"><i class="fa fa-fw fa-envelope"></i>Update Student</a>
  <a href="../shared/Logout.aspx" onclick="return confirm('Are you sure?')"><i class="fa fa-fw fa-user"></i> Logout</a></div>
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
                <asp:Label runat="server" ID="departmentlbl" Text="department"></asp:Label><asp:DropDownList  AutoPostBack="true" OnSelectedIndexChanged="ddr_TextChanged" DataTextField="name" DataValueField="name" AppendDataBoundItems="false"   ID="ddr" runat="server">
                               </asp:DropDownList>                 
                </td>
<td>
                    <asp:Label runat="server" ID="semlbl" Text="Sem"></asp:Label> <asp:DropDownList  AutoPostBack="true"  OnSelectedIndexChanged="ddr2_TextChanged" ID="ddr2" runat="server" DataTextField="sem" DataValueField="sem" AppendDataBoundItems="false">
                        <asp:ListItem Text="0" Selected="True" Value="0"></asp:ListItem>
              
                    </asp:DropDownList>  
</td>
<td><asp:Label runat="server" ID="divisionlbl" Text="division"></asp:Label><asp:DropDownList  AutoPostBack="true"  ID="ddr3" OnSelectedIndexChanged="ddr3_TextChanged"  runat="server" DataTextField="division" DataValueField="division" AppendDataBoundItems="false">
    <asp:ListItem Text="0" Selected="True" Value="0"></asp:ListItem>
                       </asp:DropDownList>  
</td>
<td><asp:Label runat="server" ID="groupbylbl" Text="group by"></asp:Label><asp:DropDownList  AutoPostBack="true"  ID="obddl" runat="server" >
                                    <asp:ListItem Selected="True" Text="Not Selected"></asp:ListItem>
                                    <asp:ListItem  Text="sem" Value="sem"></asp:ListItem>
                                                                          </asp:DropDownList>  
</td>
<td>                    <asp:Button ID="btn"  OnClick="clearSelections" Text="Clear Selections" runat="server"/>
</td></tr></table>
                 <asp:GridView  Width="100%" OnRowCancelingEdit="gv_RowCancelingEdit"  OnRowUpdating="gv_RowUpdating" OnRowEditing="gv_RowEditing" OnPageIndexChanging="GridView1_PageIndexChanging"  PagerSettings-PageButtonCount="50" ID="gv" AllowPaging="true" PageSize="25" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">
                      <Columns>
                    <asp:CommandField  ShowEditButton="true" />
                          </Columns>
    </asp:GridView>                          <asp:Button ID="approve1" Text="Update"  runat="server" onclick="approvepass1" />
                        </form>
</div>
        </div>
            </div>
              </div>

</body>
</html>

