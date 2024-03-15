using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RegistrationForm_
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-CODR1LHU\\SQLEXPRESS; initial catalog=db69_28423;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Show();
                ShowCountry();
                ShowGender();
            }

        }
        public void Show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregister join tblgender on gender=genderid join tblcountry on country=countryid join tblstate on state=stateid ",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
             da.Fill(dt);
            con.Close();
            gvregister.DataSource = dt;
            gvregister.DataBind();
        }

         public void clear()
         {
             txtname.Text = "";
             txtsalary.Text = "";
             rblgender.ClearSelection();
             ddlcountry.SelectedValue = "0";
             ddlstate.SelectedValue = "0";
             btnsave.Text = "Save";

         }

        public void ShowGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblgender", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "genderid";
            rblgender.DataTextField = "gendername";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }

        public void ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "countryid";
            ddlcountry.DataTextField = "countryname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
        }
        public void ShowState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where countryid='" + ddlcountry.SelectedValue + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "stateid";
            ddlstate.DataTextField = "statename";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
        }

       


        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblregister(name,salary,gender,country,state)values('" + txtname.Text + "','" + txtsalary.Text + "','" + rblgender.SelectedValue + "','" + ddlcountry.SelectedValue + "','" + ddlstate.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tblregister set name='" + txtname.Text + "',salary='" + txtsalary.Text + "',gender='" + rblgender.SelectedValue + "',country='" + ddlcountry.SelectedValue + "',state='" + ddlstate.SelectedValue + "' where id='" + ViewState["ID"] + "'  ", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Show();
            //clear();
        }

        protected void gvregister_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblregister where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblregister where id='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtsalary.Text = dt.Rows[0]["salary"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                ShowState();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                btnsave.Text = "Update";
                ViewState["ID"] = e.CommandArgument;
            }
        }


        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowState();
        }
    }
}