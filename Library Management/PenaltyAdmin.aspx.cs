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
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (Select_Student.SelectedIndex == 5)
            {
                ErrorMsg.Text = "Select Student";
                ErrorMsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else if (Select_Book.SelectedIndex == 5)
            {
                ErrorMsg.Text = "Select Book";
                ErrorMsg.ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where BookName='" + Select_Book.SelectedItem.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ViewState["BBID"] = dt.Rows[0]["ID"].ToString();
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();


                string qry = "select * from Addstudent where SID='" + Select_Student.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Stud_nm.Text = dataTable.Rows[0]["StudentName"].ToString();



                string Querry = "select * from AddRent where SID='"+ Convert.ToInt32(Select_Student.SelectedValue) + "' and BookName='"+ Select_Book.SelectedItem.Text + "' and Status='"+0+"'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Querry, Class1.cn);
                DataTable data = new DataTable();
                dataAdapter.Fill(data);


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
                string sql = "insert into AddPenalty values('" + Convert.ToDouble(Stud_PenaltyAmount.Text) + "','"+Stud_PenaltyReason.Text+"','"+ Convert.ToInt32(Select_Book.SelectedValue) +"')";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ErrorMsg.Text = "Amount Paid Successfully";



                string qry = "select * from AddRent where RetunDate='" + Convert.ToInt32(ViewState["RRID"].ToString()) + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                Stud_PenaltyReason.Text = "";
                Stud_PenaltyAmount.Text = "";
                MultiView1.ActiveViewIndex = -1;
                Select_Student.DataSource = data;
                Select_Student.DataTextField = "StudentName";
                Select_Student.DataValueField = "sid";
            }
        }

        protected void Select_Student_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql = "select * from AddPenalty where SID='" + Select_Student.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Select_Book.DataSource = dt;
            Select_Book.DataTextField = "BookNAme";
            Select_Book.DataValueField = "PID";
            Select_Book.DataBind();
            Select_Book.Items.Insert(0, "SELECT");
        }
    }
}
