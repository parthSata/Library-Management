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
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
            }
        }

        protected void Btn_Issue_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_days.Text == "")
                {
                    lblissue.Text = "Enter Days";
                }
                else
                {
                    if (Convert.ToInt32(Book_Available.Text) == 0)
                    {
                        lblissue.Text = "Book Stock Empty";
                    }
                    else
                    {
                        string sql = "select * from AddRent where StudentName='" + text_student.SelectedValue + "' and SID='" + text_student.SelectedValue + "'";
                        SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count != 0)
                        {
                            lblissue.Text = "Student can't get copies of same book !!";
                        }
                        else
                        {
                            string querry = "select * from AddRent where StudentName='" + text_student.SelectedValue + "' and SID='" + text_student.SelectedValue + "'";
                            SqlDataAdapter adapter = new SqlDataAdapter(querry, Class1.cn);
                            DataTable dataTable = new DataTable();
                            da.Fill(dataTable);
                            if (dataTable.Rows.Count == 3)
                            {
                                lblissue.Text = "A student has maximum 3 books";
                            }
                            else
                            {
                                string qry = "insert into AddRent values('" + text_student.SelectedValue + "')";
                                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qry, Class1.cn);
                                DataTable data = new DataTable();
                                sqlDataAdapter.Fill(dt);
                                RAdapter.Insert(Book_nm.Text, Convert.ToInt32(text_student.SelectedValue), Convert.ToInt32(TextBox1.Text));


                                BookAdapter.BOOK_ISSUE_TO_STUDENT(Convert.ToInt32(ViewState["BBID"].ToString()));
                                lblissue.Text = "Book Issued to " + text_student.SelectedItem.Text;

                                dt = BookAdapter.Select_BY_BID(Convert.ToInt32(ViewState["BBID"]));
                                ViewState["BBID"] = dt.Rows[0]["BookID"].ToString();
                                lblbname.Text = dt.Rows[0]["Bookname"].ToString();
                                lblauthor.Text = dt.Rows[0]["author"].ToString();
                                lblbran.Text = dt.Rows[0]["branch"].ToString();
                                lblpub.Text = dt.Rows[0]["publication"].ToString();
                                lblprice.Text = dt.Rows[0]["price"].ToString();
                                lblqnt.Text = dt.Rows[0]["Quantities"].ToString();
                                lblaqnt.Text = dt.Rows[0]["availableqnt"].ToString();
                                lblrqnt.Text = dt.Rows[0]["rentqnt"].ToString();

                                Book_nm.Text = dt.Rows[0]["Bookname"].ToString();
                                Book_Author.Text = dt.Rows[0]["author"].ToString();
                                Book_Branch.Text = dt.Rows[0]["branch"].ToString();
                                Book_Publication.Text = dt.Rows[0]["publication"].ToString();
                                Book_Price.Text = dt.Rows[0]["price"].ToString();
                                Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                                Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                                Book_Rent.Text = dt.Rows[0]["Rent"].ToString();

                                lbldetail.Text = dt.Rows[0]["Detail"].ToString();
                                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();

                                TextBox1.Text = "";
                                text_student.Items.Clear();
                                text_student.Items.Insert(0, "SELECT");
                                BDT = BAdapter.SelectBranch();
                                drpbranch.DataSource = BDT;
                                drpbranch.DataTextField = "Branchname";
                                drpbranch.DataValueField = "Branchid";
                                drpbranch.DataBind();
                                drpbranch.Items.Insert(0, "SELECT");
                            }
                        }
                    }
                }
            }
            catch
            {
                lblissue.Text = "Sorry !!! Error !!!";
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
                string sql = "select * from AddBook where Publication='" + DropDownList2.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                da.Fill(dt);
                BookId.Text = dt.Rows[0]["ID"].ToString();
                Book_nm.Text = dt.Rows[0]["BookName"].ToString();
                Book_Author.Text = dt.Rows[0]["Author"].ToString();
                Book_Branch.Text = dt.Rows[0]["Branch"].ToString();
                Book_Publication.Text = dt.Rows[0]["Publication"].ToString();
                Book_Price.Text = dt.Rows[0]["Price"].ToString();
                Book_Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                Book_Available.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
            }
        }
    }
}