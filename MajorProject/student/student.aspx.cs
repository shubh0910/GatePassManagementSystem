using MajorProject.shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajorProject.student
{
    public partial class student : System.Web.UI.Page
    {
        string q = "select l.username,c.name as college,d.name as department,cl.sem as class,concat(first_name,' ',middle_name,' ',surname ) as fullname from login l join student s on l.username=s.studentid join classes cl on s.classid=cl.classid join department d on cl.departmentid=d.departmentid join college c on d.collegeid=c.collegeid where l.username = @user";
        MySqlConnection con = new MySqlConnection("server=localhost; database=minorproject; uid=root; pwd=;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                setData();
        }

        private void setData()
        {
                if (Request["Username"] == null||Request.Cookies["Username"].Value == "" || Request.Cookies["Username"].Value.Length != 16|| Request.Cookies["Accesstype"].Value != "s")
                        Response.Redirect("../login.aspx");
                else if (Request.Cookies["Username"].Value.Length == 16)
                {
                MySqlCommand cmd = new MySqlCommand(q, con);
                cmd.Parameters.AddWithValue("@user", Request.Cookies["Username"].Value);
                con.Open();
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    string[] files = Directory.GetFiles(@"C:\Users\Owner\source\repos\minorproject\MajorProject\MajorProject\images", Request.Cookies["Username"].Value + ".*");
                    string strpath = Path.GetFileName(files[0]);
                    img.Attributes["src"] = ResolveUrl("/images/" + strpath);
                    PRN.Text = sdr["username"].ToString();                   
                    college.Text = sdr["college"].ToString();
                    sem.Text = sdr["class"].ToString();
                    course.Text = sdr["department"].ToString() ;
                    var textinfo = new CultureInfo("en-US", false).TextInfo;
                    Name.Text = fname.Text = textinfo.ToTitleCase(sdr["fullname"].ToString());
                    Response.Cookies.Add(CookieHelper.createcookie("fname", sdr["fullname"].ToString()));
                    sdr.Close();
                    con.Close();
                }
                ddr.DataSource = DataProvider.retrieveDataSet("select name,reasonid as id from reason");
                ddr.DataValueField = "name";
                ddr.DataBind();
                ddr.SelectedIndex = 0;
                

                try
                {  
                    string s = "";
                    s = DataProvider.retrieveString("select requestedpassid from requestedpass where DATE_FORMAT(createdtime, '%d/%m/%Y')=DATE_FORMAT(current_timestamp, '%d/%m/%Y') and username = " + Request.Cookies["Username"].Value);
                    if (s != "")
                    {
                        pl.Text = "Gatepass is requested, Wait until approved ";
                        btn.Enabled = false;
                    }
                }
                catch (Exception){}
            }

        }
     
        protected void GeneratePass(object sender, EventArgs e)
        {
            if (ddr.SelectedIndex == 0)
                pl.Text = "select reason";
            else if (ddr.SelectedIndex > 0)
            {
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                        pl.Text = "Today is holiday";
                    else
                    {
                        if (DateTime.Now.Hour > 9 && DateTime.Now.Hour < 16)
                        {
                            if (Request.Cookies["ccg"].Value == "1")
                            {
                                try
                                {
                                DataProvider.nonQuery("Insert into requestedpass (username,reasonid) values (@p1,@p2)", Request.Cookies["Username"].Value.ToString(), ddr.SelectedIndex.ToString());
                                    Response.Redirect("student.aspx");                                   
                                }
                                catch (Exception) { }

                        }
                        else
                        {
                            pl.Text = "You are restricted for creating gatepass";
                        }
                        }
                        else if (DateTime.Now.Hour < 9|| DateTime.Now.Hour > 15)
                            pl.Text = "Gatepass can be created during college hours";
                    }
            }
        }
    }
}