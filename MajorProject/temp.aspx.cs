using MajorProject.shared;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MajorProject
{
    public partial class temp : System.Web.UI.Page
    {
        string at="",qs="",s="",user="";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                setData();
            }
            
        }
        void setData()
        {
            gvCustomers.DataSource = DataProvider.retrieveDataSet("select * from college");
            gvCustomers.DataBind();
        }
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvCustomers.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlCities = (DropDownList)e.Row.FindControl("ddlCities");
                string sql = "SELECT name FROM college";

                ddlCities.DataSource = DataProvider.retrieveDataSet(sql);
                ddlCities.DataTextField = "name";
                            ddlCities.DataValueField = "name";
                            ddlCities.DataBind();
                            string selectedCity = DataBinder.Eval(e.Row.DataItem, "name").ToString();
                            ddlCities.Items.FindByValue(selectedCity).Selected = true;
            }
        }
        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {
            gvCustomers.EditIndex = e.NewEditIndex;
            setData();
        }

    }
}