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
    public partial class IssueBookReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }*/
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (Select_Branch.SelectedIndex == 20 && DropDownList1.SelectedIndex == 20)
            {
                ErrorMsg.Text = "Select Branch";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                GridView1.DataSource = null;
                GridView1.DataBind(); MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where Branch='" + Select_Branch.SelectedValue + "' and Publication='" + DropDownList1.SelectedValue + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ErrorMsg.Text = GridView1.Rows.Count.ToString() + " - Records Found";
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sql = "select * from AddBook where ID='" + e.CommandArgument.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
            Book_Id.Text = dt.Rows[0]["ID"].ToString();
            Book_nm.Text = dt.Rows[0]["BookName"].ToString();
            Book_Detail.Text = dt.Rows[0]["Detail"].ToString();
            Book_Author.Text = dt.Rows[0]["Author"].ToString();
            Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
            Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
            Book_Price.Text = dt.Rows[0]["Price"].ToString();
            Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
            Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
            Book_Rent.Text = dt.Rows[0]["Rent"].ToString();
            Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}