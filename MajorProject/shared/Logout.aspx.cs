using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajorProject
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies.Get("Username").Expires=DateTime.Now;
         //   Response.Cookies.Get("Username").Value = "";
            Response.Redirect("../login.aspx");
        }
    }
}