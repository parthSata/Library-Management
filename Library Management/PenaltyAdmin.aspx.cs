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
            if (Select_Student.SelectedIndex == 0)
            {

                ErrorMsg .Text = "Select Student";
                ErrorMsg .ForeColor = System.Drawing.Color.Red; MultiView1.ActiveViewIndex = -1;
            }
            else if (Select_Book.SelectedIndex == 0)
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
                Response.Write("<script LANGUAGE='JavaScript' >alert('You Are Now Registered ')</script>");
                MultiView1.ActiveViewIndex = 0;
                Book_nm.Text = dt.Rows[0]["Bookname"].ToString();
                Book_Author.Text = dt.Rows[0]["author"].ToString();
                Book_Branch.Text = dt.Rows[0]["branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["publication"].ToString();
                Book_Price.Text = dt.Rows[0]["price"].ToString();

                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();


                string qry = "select * from Addstudent where SID='"+ Select_Student.SelectedValue + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable dataTable = new DataTable();
                da.Fill(dt);
                Stud_nm.Text = dataTable.Rows[0]["Studentname"].ToString();






                string Querry= "select * from Addstudent where SID='" + Select_Student.SelectedValue + "' and BookName='"+ Select_Book.SelectedItem + "'";
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
            if (txtpanalty.Text == "")
            {
                lblpay.Text = "Enter amount";
            }
            else if (txtdetail.Text == "")
            {
                lblpay.Text = "Enter detail";
            }
            else
            {
                PAdapter.PENALTY_PAY_NOW(Convert.ToDouble(txtpanalty.Text), txtdetail.Text, Convert.ToInt32(Select_Book.SelectedValue));
                ErrorMsg .Text = "Amount paid successfully";
                RAdapter.RENT_SELECT_RETURN(Convert.ToInt32(ViewState["RRID"].ToString()), 1, Convert.ToInt32(ViewState["BBID"].ToString()));
                txtdetail.Text = "";
                txtpanalty.Text = "";
                MultiView1.ActiveViewIndex = -1;
                dataTable = SAdapter.Select_Student_for_panalty();
                Select_Student.DataSource = dataTable;
                Select_Student.DataTextField = "StudentName";
                Select_Student.DataValueField = "sid";
            }
        }
    }
}
