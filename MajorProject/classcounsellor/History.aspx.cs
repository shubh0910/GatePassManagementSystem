using MajorProject.shared;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace MajorProject.classcounsellor
{
    public partial class History : System.Web.UI.Page
    {
        string at = "", qs = "", s = "", user = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                at = Request.Cookies["Accesstype"].Value;
                qs = Request.QueryString["q"];

                if (at == "c")
                {
                    professor.Visible = false;
                    home.HRef = "classcounsellor.aspx";
                    updatestudent.Visible = false;
                    approvepassprofessor.Visible = false;
                    ddr.Visible = false;
                    departmentlbl.Visible = false;
                }
                else if (at == "h")
                    home.HRef = "../headofdepartment/headofdepartment.aspx";
                else
                    Response.Redirect("login.aspx");

                if (qs == "approvepassstudent")
                    approvepassstudent.Attributes.Add("class", "active");
                if (qs == "professor")
                {
                    professor.Attributes.Add("class", "active");
                    approve1.Visible = false;
                    gv.Columns.RemoveAt(0);
                }
                if (qs == "approvepassprofessor")
                    approvepassprofessor.Attributes.Add("class", "active");
                if (qs == "student")
                {
                    student.Attributes.Add("class", "active");
                    approve1.Visible = false;
                    gv.Columns.RemoveAt(0);
                }

                setData();
            }
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
        private void findQuery()
        {
            at = Request.Cookies["Accesstype"].Value;
            qs = Request.QueryString["q"];
            user = Request.Cookies["Username"].Value;

            if (at == "h")
                s = QueryProvider.queryselectorhod(qs);
            else if (at == "c")
                s = QueryProvider.queryselectorcc(qs);
            else
                s = "";
            if (qs.Contains("professor") && tb.Text.Length == 16 && tb.Text != null)
                s += " and p.professorid=" + tb.Text;
            if (qs.Contains("student") && tb.Text.Length == 16 && tb.Text != null)
                s += " and s.studentid=" + tb.Text;
            if (ddr.SelectedIndex != 0)
                s += " and d.name='" + ddr.SelectedValue + "'";
            if (ddr2.SelectedIndex != 0)
                s += " and cl.sem=" + ddr2.SelectedValue;
            if (ddr3.SelectedIndex != 0)
                s += " and cl.division=" + ddr3.SelectedValue;
            if (qs == "student" || qs == "professor")
                s += " order by outtime desc";
            else
                s += " order by createdtime desc";
            gv.DataSource = DataProvider.retrieveDataSet(s, user);
            gv.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            findQuery();
        }
        private void setData()
        {
            user = Request.Cookies["Username"].Value;
            Name.Text = Request.Cookies["fname"].Value;
            string[] files = Directory.GetFiles(@"C:\Users\Owner\source\repos\minorproject\MajorProject\MajorProject\images", user + ".*");
            string strpath = Path.GetFileName(files[0]);
            img.Attributes["src"] = ResolveUrl("/images/" + strpath);
            DataSet d = DataProvider.retrieveDataSet("call departmentProcedureHOD(" + user+")");
            ddr.DataSource = d;
            ddr.DataBind();
            findQuery();
        }

        protected void approvepass1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                var checkbox = row.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    DataProvider.nonQuery("insert into gatepass (username,createdtime,reasonid) select r.username,r.createdtime,r.reasonid from requestedpass r where r.requestedpassid=@p1", row.Cells[1].Text);
                    DataProvider.nonQuery("delete from requestedpass where requestedpassid=@p1", row.Cells[1].Text);
                }
            }
            findQuery();
        }
        protected void ddr_TextChanged(object sender, EventArgs e)
        {
            at = Request.Cookies["Accesstype"].Value;

            if (at == "h")
            {
                ddr2.DataSource = DataProvider.retrieveDataSet("call semProcedureGaurd('" + ddr.SelectedValue+"')");
                ddr2.DataBind();
                ddr2.SelectedIndex = 0;
                ddr3.DataSource = DataProvider.retrieveDataSet("call divisionProcedureHOD('" + ddr.SelectedValue + "'," + ddr2.SelectedValue + ")");
                ddr3.DataBind();
            }
            findQuery();
        }
        protected void ddr2_TextChanged(object sender, EventArgs e) {
            at = Request.Cookies["Accesstype"].Value;
            if (at == "h")
            {
                ddr3.DataSource = DataProvider.retrieveDataSet("call divisionProcedureHOD('" + ddr.SelectedValue+"',"+ddr2.SelectedValue+")");
                ddr3.DataBind();
            }
            findQuery(); 
        }
        protected void ddr3_TextChanged(object sender, EventArgs e)
        {
            findQuery();
        }
    }
}