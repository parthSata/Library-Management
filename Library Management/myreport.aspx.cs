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
    public partial class myreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Btn_Borrow_Click(object sender, EventArgs e)
        {
            string id = Session["sid"].ToString();
            string sql = "select * from AddRent where Status='"+id+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
            BorrowBook.Text = GridView1.Rows.Count.ToString();
        }

        protected void Btn_Return_Click(object sender, EventArgs e)
        {
            string id = Session["sid"].ToString();
            string sql = "select * from AddRent where Status='"+id+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
            ReturnBook.Text = GridView2.Rows.Count.ToString();
        }
        public void show()
        {


            string sql = "select * from Addstudent";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");

        }
    }
}