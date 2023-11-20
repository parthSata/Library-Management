using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class AddBranch : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf\";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_NewBranch_Click(object sender, EventArgs e)
        {
            if(text_Branch.Text != "")
            {
                string sql = "insert into AddBranch values('" + text_Branch.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
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
            text_Branch.Text = "";
            text_Branch.Focus();    
        }
    }
}