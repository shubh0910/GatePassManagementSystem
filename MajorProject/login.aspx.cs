using MajorProject.shared;
using System;

namespace MajorProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){ }
        
        protected void verifyUser(object sender, EventArgs e)
        {
            string accesstype = "",ccg="", Username="1", Password="1";
            Username = username.Text;
            Password = password.Text;
            accesstype = DataProvider.retrieveString("select accesstype from login where username="+Username+" and password='"+Password+"'");
            ccg = DataProvider.retrieveString("select cancreategatepass from login where username=" + Username + " and password='" + Password + "'");

            Response.Cookies.Add(CookieHelper.createcookie("Username", Username));
            Response.Cookies.Add(CookieHelper.createcookie("ccg", ccg));
            Response.Cookies.Add(CookieHelper.createcookie("Accesstype", accesstype));
            if (accesstype == "s")
                Response.Redirect("~/student/student.aspx");
            else if (accesstype == "")
                resonselabel.Text = "Invalid Username or password";
            else if (accesstype == "p")
                Response.Redirect("~/professor/professor.aspx");
            else if (accesstype == "c")
                Response.Redirect("~/classcounsellor/classcounsellor.aspx");
            else if (accesstype == "h")
                Response.Redirect("~/headofdepartment/headofdepartment.aspx");
            else if (accesstype == "g")
                Response.Redirect("~/gaurd/gaurd.aspx?q=updatedeparturestudent");
            else if (accesstype == "a")
                Response.Redirect("~/admin/admin.aspx");
        }

    }
}