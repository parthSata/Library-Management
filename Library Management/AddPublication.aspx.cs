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
    public partial class AddPublication : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }
       

        protected void Add_Publication_Click(object sender, EventArgs e)
        {
            if (text_publication.Text != "")
            {
                string sql = "insert into AddPublication values('" + text_publication.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                clear();
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Empty Value Allowed ')</script>");
                clear();
            }
        }
        public void clear()
        {
            text_publication.Text = "";
            text_publication.Focus();
        }
    }
}