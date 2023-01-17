<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MajorProject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" />
    <script src="login.js"></script>
</head>
<body>
    <div class="container">

        <h1>Sign In</h1>

        <form runat="server">

            <div class="form-control">
                <asp:TextBox ID="username" MaxLength="16" runat="server" ></asp:TextBox>
                <label>PRN Number</label>
            </div>

            <div class="form-control">
                <asp:TextBox ID="password" TextMode="Password" MaxLength="16" runat="server" ></asp:TextBox>
                <label>Password</label>
            </div>
            <asp:Label ID="resonselabel" runat="server" Text="" ></asp:Label>
            <asp:Button runat="server" class="btn" onclick="verifyUser" Text="Submit" type="submit"></asp:Button>

            <p class="text">
                Forget Password?
                <a href="#">Change Password</a>
            </p>

        </form>

    </div>

</body>
</html>

