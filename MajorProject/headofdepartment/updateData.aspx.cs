using MajorProject.shared;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace MajorProject.headofdepartment
{
    public partial class updateData : System.Web.UI.Page
    {
        string at = "", qs = "", s = "", user = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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
            user = Request.Cookies["Username"].Value;

                s = "select s.studentid Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name from student s join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid where s.classid in (select classid from classes where departmentid in (select departmentid from headofdepartment where headofdepartmentid=@id) ) ";
            if (tb.Text.Length == 16 && tb.Text != null)
                s += " and s.studentid=" + tb.Text;
            if (ddr.SelectedIndex != 0)
                s += " and d.name='" + ddr.SelectedValue + "'";
            if (ddr2.SelectedIndex != 0)
                s += " and cl.sem=" + ddr2.SelectedValue;
            if (ddr3.SelectedIndex != 0)
                s += " and cl.division=" + ddr3.SelectedValue;
            if (obddl.SelectedIndex != 0)
                s += " group by s.studentid Username,concat(s.first_name,' ',s.middle_name,' ',s.surname) as Name,d.name as department,cl.sem as sem,cl.division";
            s += " order by s.studentid asc";
            
            gv.DataSource = DataProvider.retrieveDataSet(s, user);
            gv.DataBind();
            gv.DataKeyNames = new string[] { "Username", "Name" };
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
            DataSet d = DataProvider.retrieveDataSet("call departmentProcedureHOD(" + user + ")");
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

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
           findQuery();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {

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
    }
}