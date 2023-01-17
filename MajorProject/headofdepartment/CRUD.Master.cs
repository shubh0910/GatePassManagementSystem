using MajorProject.shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajorProject.headofdepartment
{
    public partial class CRUD : System.Web.UI.MasterPage
    { string qs = "",at="",s="", q = "", user = "";

        protected void obddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUD1 c1 = new CRUD1();
            c1.setgvData();
        }
        protected void ddr_TextChanged(object sender, EventArgs e)
        {
            at = Request.Cookies["Accesstype"].Value;

            if (at == "h")
            {
                ddr2.DataSource = DataProvider.retrieveDataSet("call semProcedureGaurd('" + ddr.SelectedValue + "')");
                ddr2.DataBind();
                ddr2.SelectedIndex = 0;
                ddr3.DataSource = DataProvider.retrieveDataSet("call divisionProcedureHOD('" + ddr.SelectedValue + "'," + ddr2.SelectedValue + ")");
                ddr3.DataBind();
            }
            findQuery();
        }
        protected void ddr2_TextChanged(object sender, EventArgs e)
        {
            at = Request.Cookies["Accesstype"].Value;
            if (at == "h")
            {
                ddr3.DataSource = DataProvider.retrieveDataSet("call divisionProcedureHOD('" + ddr.SelectedValue + "'," + ddr2.SelectedValue + ")");
                ddr3.DataBind();
            }
            findQuery();
        }
        protected void ddr3_TextChanged(object sender, EventArgs e)
        {
            findQuery();
        }
        protected void clearSelections(object sender, EventArgs e)
        {
            tb.Text = "";
            ddr.SelectedIndex = 0;
            ddr_TextChanged(sender, e);
            ddr2.SelectedIndex = 0;
            ddr2_TextChanged(sender, e);

            findQuery();
        }
        private void setData()
        {
            user = Request.Cookies["Username"].Value;
            Name.Text = Request.Cookies["fname"].Value;
            string[] files = Directory.GetFiles(@"C:\Users\Owner\source\repos\minorproject\MajorProject\MajorProject\images", user + ".*");
            string strpath = Path.GetFileName(files[0]);
            img.Attributes["src"] = ResolveUrl("/images/" + strpath);
            DataSet d = DataProvider.retrieveDataSet("call departmentProcedureHOD(" + user + ")");
            ddr.DataSource = d;
            ddr.DataBind();
            findQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                qs = Request.QueryString["q"];
                if (qs == "studentccg")
                {
                    ContentPlaceHolder1.Visible = true;
                }
                else if (qs == "professorccg")
                {
                    ContentPlaceHolder2.Visible = true;
                }
                else if (qs == "classccg")
                {
                    ContentPlaceHolder3.Visible = true;
                }
                else if (qs == "departmentccg")
                {
                    ContentPlaceHolder4.Visible = true;
                }
                else if (qs == "studentccg")
                {
                    ContentPlaceHolder5.Visible = true;
                }
                setData();
            }            
        }

        public string findQuery()
        {   
            at = Request.Cookies["Accesstype"].Value;
            user = Request.Cookies["Username"].Value;
            s = QueryProvider.updateQuerySelector(qs);
            if (qs.Contains("professor") && tb.Text.Length == 16 && tb.Text != null)
                s += " and s.professorid=" + tb.Text;
            if (qs.Contains("student")&&tb.Text.Length == 16 && tb.Text != null)
                    s += " and s.studentid=" + tb.Text;
            if (ddr.SelectedIndex != 0)
                s += " and d.name='" + ddr.SelectedValue + "'";
            if (ddr2.SelectedIndex != 0)
                s += " and cl.sem=" + ddr2.SelectedValue;
            if (ddr3.SelectedIndex != 0)
                s += " and cl.division=" + ddr3.SelectedValue;
            if (obddl.SelectedIndex != 0)
            {
                if (obddl.SelectedIndex == 1)
                {
                    s = "SELECT d.name,c.sem,c.division from classes c join department d on c.departmentid=d.departmentid where c.departmentid in (SELECT departmentid from headofdepartment where headofdepartmentid=@id) ORDER by c.sem,c.division";
                }
                if (obddl.SelectedIndex == 2)
                {
                    s = "SELECT name from department where departmentid in (SELECT departmentid from headofdepartment where headofdepartmentid=@id)";
                }
                if (obddl.SelectedIndex == 3)
                {

                }
            }
            return s;
        }

    }
}