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
    public partial class IssueBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                ErrorMsg.Text = "Select Publication";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else if (DropDownList2.SelectedIndex == 0)
            {
                ErrorMsg.Text = "Select Book";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where [Select Publication]='" + DropDownList2.SelectedItem.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                da.Fill(dt);
                ViewState["BBID"] = dt.Rows[0]["BookID"].ToString();
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
            }
        }

        protected void Btn_Issue_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_days.Text == "")
                {
                    ErrorMsg.Text = "Enter Days";
                }
                else
                {
                    if (Convert.ToInt32(Book_Available.Text) == 0)
                    {
                        ErrorMsg.Text = "Book Stock Empty";
                    }
                    else
                    {
                        string sql = "select * from AddRent where StudentName='" + text_student.SelectedValue + "' and SID='" + text_student.SelectedValue + "'";
                        SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count != 0)
                        {
                            ErrorMsg.Text = "Student can't get copies of same book !!";
                        }
                        else
                        {
                            string querry = "select * from AddRent where StudentName='" + text_student.SelectedValue + "' and SID='" + text_student.SelectedValue + "'";
                            SqlDataAdapter adapter = new SqlDataAdapter(querry, Class1.cn);
                            DataTable dataTable = new DataTable();
                            da.Fill(dataTable);
                            if (dataTable.Rows.Count == 3)
                            {
                                ErrorMsg.Text = "A student has maximum 3 books";
                            }
                            else
                            {
                                string qry = "insert into AddPenalty values('" + text_student.SelectedValue + "')";
                                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qry, Class1.cn);
                                DataTable data = new DataTable();
                                sqlDataAdapter.Fill(data);
                                Stud_Detail.Text = "Book Issued to " + text_student.SelectedItem;




                                string query = "select * from AddBook wherd ID='" + text_student.SelectedValue + "'";
                                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, Class1.cn);
                                DataTable dataTable1 = new DataTable();
                                sqlDataAdapter.Fill(dataTable1);
                                ViewState["BBID"] = dataTable1.Rows[0]["ID"].ToString();
                                Book_nm.Text = dataTable1.Rows[0]["Bookname"].ToString();
                                Book_Detail.Text = dataTable1.Rows[0]["Detail"].ToString();
                                Book_Author.Text = dataTable1.Rows[0]["Author"].ToString();
                                Book_Branch.Text = dataTable1.Rows[0]["Branch"].ToString();
                                Book_Publication.Text = dataTable1.Rows[0]["Publication"].ToString();
                                Book_Price.Text = dataTable1.Rows[0]["Price"].ToString();
                                Book_Quantity.Text = dataTable1.Rows[0]["Quantity"].ToString();
                                Book_Available.Text = dataTable1.Rows[0]["AvailableQuantity"].ToString();
                                Book_Rent.Text = dataTable1.Rows[0]["Rent"].ToString();
                                Image2.ImageUrl = dataTable1.Rows[0]["Image"].ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                ErrorMsg.Text = "Sorry !!! Error !!!";
            }
        }

        protected void Select_Click1(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex == 9)
            {
                ErrorMsg.Text = "Select Publication";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else if (DropDownList1.SelectedIndex == 9)
            {
                ErrorMsg.Text = "Select Book";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                string sql = "select * from AddBook where BookName='" + DropDownList2.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                da.Fill(dt);

                Book_Id.Text = dt.Rows[0]["ID"].ToString();
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Detail.Text = dt.Rows[0]["Detail"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                Book_Rent.Text = dt.Rows[0]["Rent"].ToString();
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
            }
        }
    }
}