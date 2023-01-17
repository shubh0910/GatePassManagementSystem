using MajorProject.shared;
using System;
using System.Web.UI.WebControls;

namespace MajorProject.headofdepartment
{
    public partial class CRUD1 : System.Web.UI.Page
    {
        string q = "",user="";
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.Cookies["Username"].Value;

        }

        public void setgvData()
        {
            CRUD c = new CRUD();
            gv.DataSource = DataProvider.retrieveDataSet(c.findQuery(),user);
            gv.DataBind();
            gv.DataKeyNames = new string[] { "Username", "Name" };
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            setgvData();
        }
        protected void updateaccess_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gv.Rows)
            {
                var checkbox = row.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                }
            }
        }
    }
}