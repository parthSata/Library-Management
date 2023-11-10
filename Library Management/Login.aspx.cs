using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Library_Management
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cn= new SqlConnection("Data Source=DESKTOP-UN8MBH0\\SQLEXPRESS;Initial Catalog=\"Library Manage\";Integrated Security=True");  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            if (text_usename.Value != "" && text_pass.Value != "")
            {
                string str = "select * from Login  ";
                SqlDataAdapter da = new SqlDataAdapter(str, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["User_Id"] = text_usename;
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Invalid Email Or Password');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Enter Email And Password'');", true);

            }
        }
    }
}