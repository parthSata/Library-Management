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
    public partial class ReturnBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (Select_Student.SelectedIndex == 0)
            {

                ErrorMsg.Text = "Select Student";
                ErrorMsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else if (Select_Book.SelectedIndex == 0)
            {
                ErrorMsg.Text = "Select Book";
                ErrorMsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                //SELECT BOOK

                string sql = "select * from AddBook where BookName='" + Select_Book.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                Book_nm.Text = dt.Rows[0]["Bookname"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();

                //SELECT STUDENT

                string Querry = "select * from Addstudent where SID='" + Select_Student.SelectedValue + "' and BookName='" + Select_Book.SelectedItem + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Querry, Class1.cn);
                DataTable data = new DataTable();
                da.Fill(dt);
                Stud_nm.Text = dt.Rows[0]["StudentName"].ToString();
                text_days.Text = data.Rows[0]["Days"].ToString();
                Book_IssueDate.Text = data.Rows[0]["IssueDate"].ToString();

                int iday = Convert.ToDateTime(data.Rows[0]["IssueDate"].ToString()).Day;
                int rday = System.DateTime.Now.Day;

                int pday = rday - iday;
                if (pday > Convert.ToInt32(text_days.Text))
                {
                    Stud_Penalty.Text = "Yes";
                }
                else

                {
                    Stud_Penalty.Text = "NO";
                }
            }
        }

        protected void Book_Return_Click(object sender, EventArgs e)
        {

        }
    }
}