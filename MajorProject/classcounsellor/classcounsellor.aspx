<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classcounsellor.aspx.cs" Inherits="MajorProject.classcounsellor.classcounsellor" %>

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
   </style>
    
</head>
<body>

    <div class="navbar">
        <image src="/images/1.jpg" runat="server" id="img" style="margin-top:10%;" width="80%" height="250px"></image>
    <asp:Label ID="Name" runat="server" Height="32px" Text=""></asp:Label>
  <div  style="height:450px; ">
        <a class="active" style="" id="hist" runat="server" href="#"><i class="fa fa-fw fa-home"></i> Home</a><br />
  <a href="../shared/history.aspx?q=normal"  runat="server" target="_self"><i class="fa fa-fw fa-history"></i>Your Gatepass History</a>
  <a href="history.aspx?q=approvepass"  runat="server" target="_self"><i class="fa fa-fw fa-envelope"></i> Approve Student Gatepass</a>
  <a href="history.aspx?q=student"  runat="server" target="_self"><i class="fa fa-fw fa-history"></i>Student Gatepass History </a> 

  <a href="../shared/Logout.aspx" onclick="return confirm('Are you sure?')"><i class="fa fa-fw fa-user"></i> Logout</a>
</div>
        </div>
     <div  style="height:-760px; ">
    <div class="body1">
    <form runat="server">
        
    <div class="container">

                <fieldset id="fs">
           <legend>Create GatePass</legend>
                <table >
           <tr><td ><b>PRN No. :- </b></td><td> <asp:TextBox SkinID="sk" runat="server" Enabled="false" ID="PRN" Text=""></asp:TextBox></td></tr>
           <tr><td><b>Name :- </b></td><td> <asp:Label runat="server" ID="fname" Text=""></asp:Label></td></tr>
           <tr><td><b>College :- </b></td><td> <asp:Label runat="server" ID="college" Text=""></asp:Label></td></tr>           
           <tr><td><b>Department :- </b></td><td> <asp:Label runat="server" ID="course" Text=""></asp:Label></td></tr>           
        <tr><td><b>Leaving reason :- </b></td><td><asp:DropDownList  ID="ddr" runat="server" AppendDataBoundItems="true">
                                                                      <asp:ListItem Selected="True" Text="Please select"></asp:ListItem>  
                                                     </asp:DropDownList></td>  </tr>

         <tr><td></td><td style="align-content:end">       <asp:Button Width="300px" ID="btn" runat="server" OnClick="GeneratePass" Text="Create GatePass"/></td></tr>
    <tr><td colspan="2"><asp:Label runat="server" Text="" ID="pl">&nbsp</asp:Label></td></tr></table>

</fieldset>
        </div>
        </form>
            </div>
         </div>
</body>
</html>
