﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class BookReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
            lblmsg.Text = "";
            lblmsg0.Text = "";
        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");

        }
        protected void lnkview_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sql = "select * from AddBook where ID='" + Convert.ToInt32(e.CommandArgument.ToString()) + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
            Book_nm.Text = dt.Rows[0]["BookName"].ToString();
            Book_Author.Text = dt.Rows[0]["Author"].ToString();
            Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
            Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
            Book_Price.Text = dt.Rows[0]["Price"].ToString();
            Book_Total.Text = dt.Rows[0]["Quantity"].ToString();
            Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
            Book_Rent.Text = dt.Rows[0]["Rent"].ToString();
            Book_Detail.Text = dt.Rows[0]["Detail"].ToString();
            Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
            string imgPath = "/Book images/";
            Image2.ImageUrl = imgPath + Image2.ImageUrl;
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            if (Select_Branch.SelectedIndex == 10)
            {
                lblmsg.Text = "Select Branch";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where Branch='" + Select_Branch.SelectedValue + "' and Publication='" + Select_Publication.SelectedValue + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                lblmsg0.Text = GridView1.Rows.Count.ToString() + " - Records Found";
            }
        }

        /*protected void Btn_Select_Click(object sender, EventArgs e)
        {
            if (Select_Publication.SelectedIndex == 10)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblmsg.Text = "Select Publication";
                lblmsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where Publication='" + Select_Publication.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1); 
                GridView1.DataSource = dt;
                GridView1.DataBind();
                lblmsg0.Text = GridView1.Rows.Count.ToString() + " - Records Found";

            }
        }*/
    }
}