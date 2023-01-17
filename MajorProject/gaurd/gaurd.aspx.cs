using MajorProject.shared;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace MajorProject.gaurd
{
    public partial class gaurd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
                if (Request.QueryString["q"].Contains("professor")){
                    semlbl.Visible = false;
                    ddr3.Visible = false;
                }
                if (Request.QueryString["q"] == "updatedeparturestudent")
                    updatedeparturestudent.Attributes.Add("class", "active");
                else if(Request.QueryString["q"] == "updatedepartureprofessor")
                    updatedepartureprofessor.Attributes.Add("class", "active");
                else if (Request.QueryString["q"] == "updatearrivalstudent")
                    updatearrivalstudent.Attributes.Add("class", "active");
                else if (Request.QueryString["q"] == "updatearrivalprofessor")
                    updatearrivalprofessor.Attributes.Add("class", "active");
                Name.Text = DataProvider.retrieveString("select concat(first_name,' ',middle_name,' ',surname) from gaurd where gaurdid=" + Request.Cookies["Username"].Value);
                string[] files = Directory.GetFiles(@"C:\Users\Owner\source\repos\minorproject\MajorProject\MajorProject\images", Request.Cookies["Username"].Value + ".*");
                string strpath = Path.GetFileName(files[0]);
                img.Attributes["src"] = ResolveUrl("/images/" + strpath);
                ddr.DataSource = DataProvider.retrieveDataSet("select name from college");
                ddr.DataBind();
               
            }
        }
        protected void clearSelections(object sender, EventArgs e)
        {
            tb.Text = "";
            ddr.SelectedIndex = 0;
            ddr2_TextChanged(sender, e);
            ddr2.SelectedIndex = 0;
            ddr3_TextChanged(sender, e);
            
            findQuery();
        }
        protected void ddr2_TextChanged(object sender, EventArgs e)
        {
            ddr2.DataSource = DataProvider.retrieveDataSet("call departmentProcedureGaurd(" + ddr.SelectedIndex+")");
            ddr2.DataBind();
           
            findQuery();
        }

        protected void ddr3_TextChanged(object sender, EventArgs e)
        {
            ddr3.DataSource = DataProvider.retrieveDataSet("call semProcedureGaurd('" + ddr2.SelectedValue + "')");
            ddr3.DataBind();
            findQuery();
        }
        protected void ddr4_TextChanged(object sender, EventArgs e)
        {
            findQuery();
        }
        private void setData()
        {
            if (Request["Username"] != null&&Request.Cookies["Username"].Value.Length == 16&& Request.Cookies["Accesstype"].Value == "g")
                findQuery();
            else
                Response.Redirect("../login.aspx");
        }

        protected void updatetime(object sender, EventArgs e)
        {
            string qry = "";
            qry = QueryProvider.gaurdQuery(Request.QueryString["q"]);
            foreach (GridViewRow row in gv.Rows)
            {
                var checkbox = row.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                    DataProvider.nonQuery(qry, row.Cells[1].Text);
            }
            findQuery();
        }
       private void findQuery()
        {
            string qs = Request.QueryString["q"];
            string s = QueryProvider.gaurdSelectQuery(qs);
            if (qs.Contains("professor") && tb.Text.Length == 16 && tb.Text != null)
                s += " and s.professorid=" + tb.Text;
            if (qs.Contains("student") && tb.Text.Length == 16 && tb.Text != null)
                s += " and s.studentid=" + tb.Text;
            if (ddr.SelectedIndex != 0)
                s += " and c.collegeid=" + ddr.SelectedIndex;
            if (ddr2.SelectedIndex != 0)
                s += " and d.name='" + ddr2.SelectedValue+"'";
            if (ddr3.SelectedIndex != 0)
                s += " and cl.sem=" + ddr3.SelectedValue;
            
                s += " order by createdtime desc";
            gv.DataSource = DataProvider.retrieveDataSet(s);
            gv.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            findQuery();
        }
    }
}