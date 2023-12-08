// issue Book
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
                                string qry = "insert into AddRent values('" + Book_nm.Text+ "','"+ text_student.SelectedValue + "','"+text_days.Text+"')";
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

                Book_Id.Text = dt.Rows[0]["BID"].ToString();
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Detail.Text = dt.Rows[0]["Detail"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                Book_Rent.Text = dt.Rows[0]["RentQuantity"].ToString();
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
            }
        }
    }
}

//Returm Book

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
                //SELECT BOOK

                string sql = "select * from AddBook where BookName='" + Select_Book.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
               /* Image2.ImageUrl = dt.Rows[0]["Image"].ToString();*/

                //SELECT STUDENT

                string Querry = "select * from AddRent where SID='"+ Select_Student.SelectedValue+ "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Querry, Class1.cn);
                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                Book_nm.Text = data.Rows[0]["BookName"].ToString();
                text_days.Text = data.Rows[0]["Days"].ToString();
                Book_IssueDate.Text = data.Rows[0]["IssueDate"].ToString();


                string qry = "select * from AddRent where SID='" + Select_Student.SelectedValue + "'and BookName='" + Book_nm.Text + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qry, Class1.cn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                Book_nm.Text = dataTable.Rows[0]["BookName"].ToString();
                text_days.Text = dataTable.Rows[0]["Days"].ToString();
                Book_IssueDate.Text = dataTable.Rows[0]["IssueDate"].ToString();
                ViewState["RRID"] = dataTable.Rows[0]["rid"].ToString();
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
            if (Stud_Penalty.Text == "Yes")
            {
                lblbook.Text = "Please, first pay Penalty";
                lblbook.ForeColor = System.Drawing.Color.Red;

                string sql = "select * from AddPenalty where SID='" + Select_Student.SelectedValue + "' and BookName='" + Book_nm.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    string qry = "insert into AddPenalty values('" + Select_Student.Text + "','"+Book_nm.Text+"','"+Book_Price.Text+"')";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, Class1.cn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    Response.Write("Inserted");
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["Penalty"].ToString() != "0")
                        {
                            string qry = "insert into AddPenalty values('" + Select_Student.Text + "','" + Book_nm.Text + "','" + Book_Price.Text + "')";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, Class1.cn);
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            Response.Write("Inserted Penalty");
                            break;
                        }
                    }


                }
            }
            else
            {
                string sql = "select * from AddRent where BBID='" + Convert.ToInt32(ViewState["BBID"].ToString()) + "' and RRID='" + Convert.ToInt32(ViewState["RRID"].ToString()) + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lblbook.Text = "Book Return Successfully";
                lblbook.ForeColor = System.Drawing.Color.Green;

            }
        }
    }
}
