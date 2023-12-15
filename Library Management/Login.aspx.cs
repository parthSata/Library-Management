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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RdoAdmin.Checked == true)
            {

                if (text_username.Value != "" && text_pass.Value != "")
                {
                    string str = "select * from Login where username='" + text_username.Value + "'and password='" + text_pass.Value + "'";
                    SqlDataAdapter da = new SqlDataAdapter(str, Class1.cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Session["sid"] = dt.Rows[0]["AID"].ToString();
                        Session["email"] = text_username.Value;
                        Session["name"] = dt.Rows[0]["Name"].ToString();
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
            else
            {
                if (text_username.Value != "" && text_pass.Value != "")
                {
                    string str = "select * from Addstudent where Email='" + text_username.Value + "'and Password='" + text_pass.Value + "'";
                    SqlDataAdapter da = new SqlDataAdapter(str, Class1.cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Session["sid"] = dt.Rows[0]["SID"].ToString();
                        Session["email"] = text_username.Value;
                        Response.Redirect("MyAccount.aspx");
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
}