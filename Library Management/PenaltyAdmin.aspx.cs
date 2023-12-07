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
    public partial class PenaltyAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (Select_Student.SelectedIndex == 5)
            {

                ErrorMsg .Text = "Select Student";
                ErrorMsg .ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else if (Select_Book.SelectedIndex == 5)
            {
                ErrorMsg .Text = "Select Book";
                ErrorMsg .ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where BookName='" + Select_Book.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MultiView1.ActiveViewIndex = 0;
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();

                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();


                string qry = "select * from Addstudent where SID='"+ Select_Student.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable dataTable = new DataTable();
                da.Fill(dt);
                Stud_nm.Text = dataTable.Rows[0]["StudentName"].ToString();






                string Querry= "select * from AddRent where SID='" + Select_Student.SelectedValue + "' and BookName='"+ Select_Book.SelectedItem + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable data = new DataTable();
                da.Fill(dt);
                text_days.Text = data.Rows[0]["Days"].ToString();
                Book_IssueDate.Text = data.Rows[0]["IssueDate"].ToString();
                ViewState["RRID"] = data.Rows[0]["rid"].ToString();

                int iday = Convert.ToDateTime(data.Rows[0]["IssueDate"].ToString()).Day;
                int rday = System.DateTime.Now.Day;

                int pday = rday - iday;
                if (pday > Convert.ToInt32(text_days.Text))
                {
                    Stud_Pay.Text = "Yes";
                }
                else
                {
                    Stud_Pay.Text = "NO";
                }
            }
        }

        protected void btnpaypanalty_Click(object sender, EventArgs e)
        {
            if (Stud_PenaltyAmount.Text == "")
            {
                Stud_Pay.Text = "Enter amount";
            }
            else if (Stud_PenaltyReason.Text == "")
            {
                Stud_Pay.Text = "Enter detail";
            }
            else
            {
                string sql = "select * from AddRent where RetunDate='" + Convert.ToInt32(ViewState["RRID"].ToString()) + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Stud_PenaltyReason.Text = "";
                Stud_PenaltyAmount.Text = "";
                MultiView1.ActiveViewIndex = -1;
                Select_Student.DataSource = dt;
                Select_Student.DataTextField = "StudentName";
                Select_Student.DataValueField = "sid";
            }
        }
    }
}
