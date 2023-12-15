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
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
        }
        public void clear()
        {
            text_days.Text = "";
            Response.Write("<script LANGUAGE='JavaScript' >alert('Your Book Issued')</script>");

        }

        protected void Select_Click1(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 9)
            {
                Stud_Detail.Text = "Select Publication";
                Stud_Detail.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else if (DropDownList2.SelectedIndex == 9)
            {
                Stud_Detail.Text = "Select Book";
                Stud_Detail.ForeColor = System.Drawing.Color.Red;
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

                Select_student.Items.Clear();
                Select_student.Items.Insert(0, "SELECT");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (text_days.Text == "")
            {
                Stud_Detail.Text = "Enter Days";
            }
            else
            {
                if (Convert.ToInt32(Book_Available.Text) == 0)
                {
                    Stud_Detail.Text = "Book Stock Empty";
                }
                else
                {
                    string sql = "select * from AddRent where BookName='" + Book_nm.Text + "' and SID='" + Select_student.SelectedValue + "'and Status='"+Select_Status.SelectedValue+"'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count != 0)
                    {
                        Stud_Detail.Text = "Student can't get copies of same book !!";
                    }
                    else
                    {
                        string querry = "select * from AddRent where SID='" + Select_student.SelectedValue + "' and Status='"+Select_Status.SelectedValue+"'";
                        SqlDataAdapter adapter = new SqlDataAdapter(querry, Class1.cn);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 3)
                        {
                            Stud_Detail.Text = "A student has maximum 3 books";
                        }
                        else
                        {
                            string qry = "INSERT INTO AddRent (BookName, SID, Days, IssueDate, Status) VALUES ('" + Book_nm.Text + "','" + Convert.ToInt32(Select_student.SelectedValue) + "','" + text_days.Text + "','" + DateTime.Now.ToShortDateString() + "','"+Select_Status.SelectedValue+"')";
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qry, Class1.cn);
                            Response.Write(qry);
                            DataTable data = new DataTable();
                            sqlDataAdapter.Fill(data);
                            Response.Write("<script LANGUAGE='JavaScript' >alert('Inserted ')</script>");

                            Stud_Detail.Text = "Book Issued to " + Select_student.SelectedItem;


                            string query = "select * from AddBook where ID='" + Convert.ToInt32(ViewState["BBID"]) + "'";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, Class1.cn);
                            Response.Write(query);
                            DataTable dataTable1 = new DataTable();
                            dataAdapter.Fill(dataTable1);

                            ViewState["BBID"] = dataTable1.Rows[0]["ID"].ToString();
                            Book_nm.Text = dataTable1.Rows[0]["BookName"].ToString();
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from AddBook where Publication='" + DropDownList1.SelectedItem.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Bookname";
            DropDownList2.DataValueField = "Bookid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "SELECT");
        }
}