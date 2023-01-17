using MajorProject.shared;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace MajorProject.student
{
    public partial class history : System.Web.UI.Page
    {
        string at="",user="";
        string q = "select ROW_NUMBER() Over(ORDER BY createdtime desc) AS No,createdtime,name as reason,varifiedtime,outtime,intime from gatepass g join reason r on g.reasonid = r.reasonid where username =@id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menuHandler();              
                setData();
            }  
        }
        private void menuHandler()
        {
            if (Request["Accesstype"] != null)
            {
                 at = Request.Cookies["Accesstype"].Value;
                if (at == "p")
                {
                    home.HRef = "../professor/professor.aspx";
                }
                else if ("s" == at)
                {
                    home.HRef = "../student/student.aspx";
                }
                else if (at == "c")
                {
                    home.HRef = "../classcounsellor/classcounsellor.aspx";
                    updatestudent.Visible = false;
                    approvepassprofessor.Visible = false;
                    professor.Visible = false;
                }
                else if (at == "h")
                {
                    home.HRef = "../headofdepartment/headofdepartment.aspx";
                }
                else if (at== "a")
                {
                    home.HRef = "../admin/admin.aspx";
                }
                if (at== "p" || at == "s")
                {
                    student.Visible = false;
                    updatestudent.Visible = false;
                    approvepassstudent.Visible = false;
                    approvepassprofessor.Visible = false;
                    professor.Visible = false;

                }
            }
        }
       
      
        private void setData()
        {
            if (Request["Username"] == null)
            {
                  Response.Redirect("../login.aspx");
            }
            else if (Request.Cookies["Username"].Value.Length == 16)
            {
                Name.Text = Request.Cookies["fname"].Value;
                user = Request.Cookies["Username"].Value;
                string[] files = Directory.GetFiles(@"C:\Users\Owner\source\repos\minorproject\MajorProject\MajorProject\images",user+ ".*");
                string strpath = Path.GetFileName(files[0]);
                img.Attributes["src"] = ResolveUrl("/images/" + strpath);
                DataSet d = DataProvider.retrieveDataSet(q, user);
                gv.DataSource = d;
                gv.DataBind();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }

        }
     

protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = DataProvider.retrieveDataSet(q, user);
            gv.DataBind();
        }
    }
}