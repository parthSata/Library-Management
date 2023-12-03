using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection.Emit;


namespace Library_Management
{
    public partial class MyAccount : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["sid"].ToString();
            Label1.Text = "";
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
            string sql = "select * from Addstudent where SID='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Label1.Text = dt.Rows[0][1].ToString();
            lbl_nm.Text = dt.Rows[0]["StudentName"].ToString();
            lbl_mo.Text = dt.Rows[0]["Mobile"].ToString();
            lbl_Address.Text = dt.Rows[0]["Address"].ToString();
            lbl_City.Text = dt.Rows[0]["City"].ToString();
            lbl_Pin.Text = dt.Rows[0]["Pincode"].ToString();
            lbl_Email.Text = dt.Rows[0]["Email"].ToString();
        }


        protected void Btn_View_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View3);
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            string sql = "update Addstudent SET [StudentName]='" + text_nm.Text + "',Branch='" + text_branch.SelectedValue + "',Gender='" + text_gender.SelectedValue + "',Birthdate='" + text_birthdate.Text + "',Mobile='" + text_mo.Text + "',Address='" + text_address.Text + "',City='" + text_city.Text + "',Pincode='" + text_pin.Text + "',Email='" + text_email.Text + "',Password='" + text_pass.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response.Write("updated");

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");

        }
    }
}