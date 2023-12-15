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
    public partial class AddBook : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Btn_AddBook_Click(object sender, EventArgs e)
        {
            if (text_BookName.Text != "" && text_Detail.Text != "" && text_Author.Text != "" && text_Publication.Text != "" && text_Branch.Text != "" && text_Price.Text != "" && text_Quantity.Text != "" &&  text_Entry.Text != "" && FileUpload1.FileName != "")
            {

                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension == ".png" || fileExtension == ".jpg")
                {
                    FileUpload1.SaveAs(Server.MapPath("Book images/" + FileUpload1.FileName));
                    string sql = "insert into AddBook values('" + text_BookName.Text + "','" + text_Detail.Text + "','" + text_Author.Text + "','" + text_Publication.SelectedValue + "','" + text_Branch.Text + "','" + text_Price.Text + "','" + text_Quantity.Text + "','"+ text_Quantity.Text +"','"+0+"','"+ text_Entry.Text + "','" + FileUpload1.FileName + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (text_Entry.Text != "" && Convert.ToDateTime(text_Entry.Text) > DateTime.Today)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Enter Valid Date ')</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('You Are Now Registered ')</script>");
                        clear();
                    }
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Empty Value Allowed ')</script>");
                clear();
            }

        }
        public void clear()
        {
            text_BookName.Text = "";
            text_Detail.Text = "";
            text_Author.Text = "";
            text_Price.Text = "";
            text_Quantity.Text = "";
            text_Available.Text = "";
            text_Entry.Text = "";
            text_BookName.Focus();
        }
    }
}
