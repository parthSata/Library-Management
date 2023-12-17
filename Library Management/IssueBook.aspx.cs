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
        //SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf;Integrated Security=True;Connect Timeout=30");

        string cn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                // Populate the Publication dropdown
                DropDownList1.DataBind();

                // Populate the Book dropdown based on the selected Publication
                DropDownList2.DataBind();
            }
        }
        public void clear()
        {
            text_days.Text = "";
            Response.Write("<script LANGUAGE='JavaScript' >alert('Your Book Issued')</script>");

        }

        protected void Select_Click1(object sender, EventArgs e)
        {
            FetchBookDetails(DropDownList2.SelectedValue);

            // Show the second view in the MultiView
            MultiView1.SetActiveView(View1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            IssueBookToStudent();
        }

        private void FetchBookDetails(string bookName)
        {
            using (SqlConnection con = new SqlConnection(cn))
            {
                string query = "SELECT * FROM AddBook WHERE BookName = @BookName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BookName", bookName);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate book details in the labels
                            Book_Id.Text = reader["ID"].ToString();
                            Book_nm.Text = reader["BookName"].ToString();
                            // Populate other book details similarly
                        }
                    }
                }
            }
        }

        private void IssueBookToStudent()
        {
            // Get the selected book and student details
            string bookName = DropDownList2.SelectedValue;
            string studentName = Select_student.SelectedValue;
            string branchName = text_branch.SelectedValue;
            int days = Convert.ToInt32(text_days.Text);

            // You may want to perform additional validation here

            using (SqlConnection con = new SqlConnection(cn))
            {
                // Start a SQL transaction to ensure atomicity
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Update the Book table to reduce the available quantity
                    string updateBookQuery = "UPDATE AddBook SET AvailableQuantity = AvailableQuantity - 1 WHERE BookName = @BookName";
                    using (SqlCommand cmdUpdateBook = new SqlCommand(updateBookQuery, con, transaction))
                    {
                        cmdUpdateBook.Parameters.AddWithValue("@BookName", bookName);
                        cmdUpdateBook.ExecuteNonQuery();
                    }

                    // Insert a record into the IssuedBooks table
                    string insertIssuedBookQuery = "INSERT INTO AddRent (BookName, StudentName, BranchName, IssueDate, DueDate) VALUES (@BookName, @StudentName, @BranchName, GETDATE(), DATEADD(day, @Days, GETDATE()))";
                    using (SqlCommand cmdInsertIssuedBook = new SqlCommand(insertIssuedBookQuery, con, transaction))
                    {
                        cmdInsertIssuedBook.Parameters.AddWithValue("@BookName", bookName);
                        cmdInsertIssuedBook.Parameters.AddWithValue("@StudentName", studentName);
                        cmdInsertIssuedBook.Parameters.AddWithValue("@BranchName", branchName);
                        cmdInsertIssuedBook.Parameters.AddWithValue("@Days", days);
                        cmdInsertIssuedBook.ExecuteNonQuery();
                    }

                    // Commit the transaction if all operations succeed
                    transaction.Commit();

                    // Optionally, you can display a success message or redirect the user to a confirmation page
                    Response.Write("Book issued successfully!");
                }
                catch (Exception ex)
                {
                    // An error occurred, rollback the transaction
                    transaction.Rollback();

                    // Log the exception or handle it as needed
                    Response.Write($"Error issuing book: {ex.Message}");
                }
            }
        }

    }
}