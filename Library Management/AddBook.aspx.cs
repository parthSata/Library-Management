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
        SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf\";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_AddBook_Click(object sender, EventArgs e)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
          /*  if (text_BookName.Text != "" && text_Detail.Text != "" && text_Author.Text != "" && text_Publication.Text != "" && text_Branch.Text != "" && text_Price.Text != "" && text_Quantity.Text != "" && FileUpload1.FileName != "")
            {*/
                if (fileExtension == ".pdf" || fileExtension == ".jpg")
                {
                    FileUpload1.SaveAs(Server.MapPath("images/" + FileUpload1.FileName));
                    string sql = "insert into AddBook values('" + text_BookName.Text + "','" + text_Detail.Text + "','" + text_Author.Text + "','" + text_Publication.SelectedValue + "','" + text_Branch.Text + "','" + text_Price.Text + "','" + text_Quantity.Text + "','" + FileUpload1.FileName + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Response.Write("<script LANGUAGE='JavaScript' >alert('You Are Now Registered ')</script>");
                    clear();
           
                }
          /*  }

            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('No Empty Value Allowed ')</script>");
                clear();
            }*/
        }

        public void show()
        {

            string sql = "select * from AddPublication";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
        public void clear()
        {
            text_BookName.Text = "";
            text_Detail.Text = "";
            text_Author.Text = "";
            text_Publication.Text = "";
            text_Branch.Text = "";
            text_Price.Text = "";
            text_Quantity.Text = "";
        
            text_BookName.Focus();
        }
    }
}
