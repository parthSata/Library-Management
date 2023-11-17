using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Library_Management
{
    public partial class AddStudent : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-UN8MBH0\\SQLEXPRESS;Initial Catalog=\"Library Manage\";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_NewStudent_Click(object sender, EventArgs e)
        {

            if (text_nm.Text != "" && text_branch.Text != "" && text_gender.Text != "" && text_birthdate.Text != "" && text_mo.Text != "" && text_address.Text != "" && text_city.Text != "" && text_pin.Text != "" && text_email.Text != "" && text_pass.Text != "")
            {
                string strpass = encryptpass(text_pass.Text);
                string sql = "insert into Addstudent values('" + text_nm.Text + "','" + text_branch.Text + "','" + text_gender.Text + "','" + text_birthdate.Text + "','" + text_mo.Text + "','" + text_address.Text + "','" + text_city.Text + "','" + text_pin.Text + "','" + text_email.Text + "','" + strpass + "')";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                show();
                Response.Write("<script LANGUAGE='JavaScript' >alert('You Are Now Registered ')</script>");
                clear();
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Empty Value Allowed ')</script>");
                clear();
            }

        }
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        public void show()
        {


            string sql = "select * from Addstudent";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
        public void clear()
        {
            text_nm.Text = "";
            text_branch.Text = "";
            text_gender.Text = "";
            text_birthdate.Text = "";
            text_mo.Text = "";
            text_address.Text = "";
            text_city.Text = "";
            text_pin.Text = "";
            text_email.Text = "";
            text_pass.Text = "";
            text_nm.Focus();
        }

    }
}