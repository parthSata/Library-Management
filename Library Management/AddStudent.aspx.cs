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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Add_NewStudent_Click(object sender, EventArgs e)
        {
            string fileExtension = System.IO.Path.GetExtension(text_photo.FileName);
            if (fileExtension == ".png" || fileExtension == ".jpg")
            {
                text_photo.SaveAs(Server.MapPath("images/" + text_photo.FileName));
                if (text_nm.Text != "" && text_branch.Text != "" && text_gender.Text != "" && text_birthdate.Text != "" && text_mo.Text != "" && text_address.Text != "" && text_city.Text != "" && text_pin.Text != "" && text_email.Text != "" && text_pass.Text != "" && text_photo.FileName != "")
                {
                    //string strpass = encryptpass(text_pass.Text);
                    string sql = "insert into Addstudent values('" + text_nm.Text + "','" + text_branch.SelectedValue + "','" + text_gender.SelectedValue + "','" + text_birthdate.Text + "','" + text_mo.Text + "','" + text_address.Text + "','" + text_city.Text + "','" + text_pin.Text + "','" + text_email.Text + "','" + text_pass.Text + "','" + text_photo.FileName + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    show();
                    if (text_birthdate.Text != "" && Convert.ToDateTime(text_birthdate.Text) > DateTime.Today)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Enter Valid Date ')</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('You Are Now Registered ')</script>");
                        clear();
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('No Empty Value Allowed ')</script>");
                }
            }

        }
        /*  public string encryptpass(string password)
          {
              string msg = "";
              byte[] encode = new byte[password.Length];
              encode = Encoding.UTF8.GetBytes(password);
              msg = Convert.ToBase64String(encode);
              return msg;
          }*/
        public void show()
        {


            string sql = "select * from Addstudent";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
        public void clear()
        {
            text_nm.Text = "";
            text_birthdate.Text = "";
            text_mo.Text = "";
            text_address.Text = "";
            text_city.Text = "";
            text_pin.Text = "";
            text_email.Text = "";
            text_pass.Text = "";
            text_nm.Focus();
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }
    }
}