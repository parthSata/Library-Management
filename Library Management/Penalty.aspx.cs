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
    public partial class Penalty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
               
            }*/
           
                string sql = "select * from AddPenalty where SID='" + Convert.ToInt32(Session["sid"].ToString()) + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView3.DataSource = dt;
                GridView3.DataBind();

            
        }
        protected void Btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");

        }

    }
}