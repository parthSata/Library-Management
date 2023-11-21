using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;

namespace Library_Management
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cn= new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf\";Integrated Security=True");  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (text_username.Value != "" && text_pass.Value != "")
            {
                string str = "select * from AddStudent where Email='" + text_username.Value + "'and Password='" + text_pass.Value + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["User_Id"] = text_username;
                    Response.Redirect("AddPublication.aspx");
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