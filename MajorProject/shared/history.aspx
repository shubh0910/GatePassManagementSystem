<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="history.aspx.cs" Inherits="MajorProject.student.history" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="history.css" rel="stylesheet" />
 
</head>
<body>
    <div >
     <div class="navbar">
        <image src="/images/1.jpg" runat="server" id="img" style="margin-top:10%;" width="80%" height="250px"></image>
    <asp:Label ID="Name" runat="server" Height="30px" Text=" SHubh Sureshbhai Patel"></asp:Label>
  <div  style="height:450px; ">
 <a id="home" runat="server" href="#"><i class="fa fa-fw fa-home"></i> Home</a><br />
  <a href="../shared/history.aspx?q=normal"  runat="server" target="_self"><i class="fa fa-fw fa-history"></i>Your Gatepass History</a>
  <a href="../classcounsellor/history.aspx?q=approvepassstudent"  id="approvepassstudent" runat="server"><i class="fa fa-fw fa-confirm"></i> Approve Student Gatepass</a>
  <a href="../classcounsellor/history.aspx?q=approvepassprofessor"  id="approvepassprofessor" runat="server"><i class="fa fa-fw fa-approve"></i> Approve Professor Gatepass</a>
  <a href="../classcounsellor/history.aspx?q=student" id="student" runat="server" ><i class="fa fa-fw fa-history"></i>Student Gatepass History </a>
  <a href="../classcounsellor/history.aspx?q=professor" id="professor" runat="server" ><i class="fa fa-fw fa-history"></i>Professor Gatepass History </a>
  <a href="../headofdepartment/updateData.aspx" id="updatestudent" runat="server"><i class="fa fa-fw fa-envelope"></i>Update Student</a>
  <a href="Logout.aspx" onclick="return confirm('Are you sure?')"><i class="fa fa-fw fa-user"></i> Logout</a></div>
         </div>
        <div id="mdv" >

         <div class="body1">        
    <div class="container">

          <div id="dgv">
                    <form runat="server">
                 <asp:GridView  Width="100%"  OnPageIndexChanging="GridView1_PageIndexChanging"  ID="gv" AllowPaging="true" PageSize="25" PagerSettings-Mode="Numeric"  RowStyle-BackColor="Teal" HeaderStyle-Font-Bold="false" PagerStyle-BackColor="Yellow" PagerStyle-Font-Size="Medium" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Size="Medium" HeaderStyle-BackColor="SlateBlue" HeaderStyle-BorderWidth="3px"  RowStyle-BorderWidth="2px" RowStyle-ForeColor="black"  RowStyle-Font-Size="Medium" AutoGenerateColumns="true" runat="server">
                   
    </asp:GridView>  
                        </form>
</div>
        </div>
            </div>
              
        </div>
        </div>
</body>
</html>
