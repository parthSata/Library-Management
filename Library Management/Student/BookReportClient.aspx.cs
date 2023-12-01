using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class BookReportClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_ViewBranch_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 5)
            {
                ErrorMsg.Text = "Select Branch";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                GridView1.DataSource = null;
                GridView1.DataBind();
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where Branch='" + DropDownList1.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ErrorMsg.Text = GridView1.Rows.Count.ToString() + " - Records Found";
            }
        }

        protected void Btn_ViewPublication_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex == 10)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ErrorMsg.Text = "Select Publication";
                ErrorMsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where Publication='" + DropDownList2.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ErrorMsg.Text = GridView1.Rows.Count.ToString() + " - Records Found";

            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

       /* protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sql = "select * from AddBook where ID='" + e.CommandArgument.ToString()+ "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
            da.Fill(dt);
            Book_nm.Text = dt.Rows[0]["BookName"].ToString();
            Book_Author.Text = dt.Rows[0]["Author"].ToString();
            Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
            Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
            Book_Price.Text = dt.Rows[0]["Price"].ToString();
            Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
            Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
            Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
        }*/

        protected void lnkview_Click1(object sender, EventArgs e)
        {
            string sql = "select * from AddBook where Branch='" + DropDownList1.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
            da.Fill(dt);
            Book_nm.Text = dt.Rows[0]["BookName"].ToString();
            Book_Author.Text = dt.Rows[0]["Author"].ToString();
            Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
            Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
            Book_Price.Text = dt.Rows[0]["Price"].ToString();
            Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
            Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
            Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
        }
    }
}