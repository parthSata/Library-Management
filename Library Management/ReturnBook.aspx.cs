﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

namespace Library_Management
{
    public partial class ReturnBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["sid"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }*/

            string sql = "select * from AddRent where SID='" + Select_Student.SelectedValue + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            Select_Student.Items.Insert(0, "SELECT");
            Select_Book.Items.Insert(0, "SELECT");
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            if (Select_Student.SelectedIndex == 5)
            {

                ErrorMsg.Text = "Select Student";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else if (Select_Book.SelectedIndex == 5)
            {
                ErrorMsg.Text = "Select Book";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                //SELECT BOOK

                string sql = "select * from AddBook where BookName='" + Select_Book.SelectedItem.Text + "'";
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
                Image2.ImageUrl = dt.Rows[0]["Image"].ToString();
                string imgPath = "/Book images/";
                Image2.ImageUrl = imgPath + Image2.ImageUrl;

                //SELECT STUDENT

                int selectedSID;
                if (int.TryParse(Select_Student.SelectedValue, out selectedSID))
                {
                    string Querry = "select * from Addstudent where SID='" + selectedSID + "'";
                    using (SqlCommand cmd = new SqlCommand(Querry, Class1.cn))
                    {
                        cmd.Parameters.AddWithValue("@SID", selectedSID);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dataAdapter.Fill(data);
                        Stud_nm.Text = data.Rows[0]["StudentName"].ToString();
                    }
                }
                

                int SelectedSID;
                if (int.TryParse(Select_Student.SelectedValue, out SelectedSID))
                {
                    string qry = "SELECT * FROM AddRent WHERE SID = @SID AND BookName = @BookName AND Status = @Status";

                    using (SqlCommand cmd = new SqlCommand(qry, Class1.cn))
                    {
                        cmd.Parameters.AddWithValue("@SID", SelectedSID);
                        cmd.Parameters.AddWithValue("@BookName", Select_Book.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Status", "Yes");

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        Book_IssueDate.Text = dataTable.Rows[0]["IssueDate"].ToString();
                        ViewState["RRID"] = dataTable.Rows[0]["RID"].ToString();
                        ViewState["BookName"] = dataTable.Rows[0]["BookName"].ToString();
                    }
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
                    string qry = "insert into AddPenalty values('" + Select_Student.Text + "','" + Book_nm.Text + "','" + Book_Price.Text + "')";
                    SqlDataAdapter adapter = new SqlDataAdapter(qry, Class1.cn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["Panalty"].ToString() != "0")
                        {
                            string querry = "insert into AddPenalty values('" + Select_Student.Text + "','" + Book_nm.Text + "','" + Book_Price.Text + "')";
                            SqlDataAdapter adapter = new SqlDataAdapter(querry, Class1.cn);
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
                if (ViewState["RRID"] != null && ViewState["BookName"] != null)
                {
                    string query = "SELECT * FROM AddRent WHERE RID = @RID AND BookName = @BookName";
                    using (SqlCommand cmd = new SqlCommand(query, Class1.cn))
                    {
                        cmd.Parameters.AddWithValue("@RID", ViewState["RRID"].ToString());
                        cmd.Parameters.AddWithValue("@BookName", ViewState["BookName"].ToString());

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dataAdapter.Fill(data);

                        if (data.Rows.Count > 0)
                        {
                            lblbook.Text = "Book Return Successfully";
                            lblbook.ForeColor = System.Drawing.Color.Green;
                        }


                    }
                    string sql = "delete from AddRent where RID=@RID";
                    using (SqlCommand command = new SqlCommand(sql, Class1.cn))
                    {
                        command.Parameters.AddWithValue("@RID", ViewState["RRID"].ToString());
                        command.Parameters.AddWithValue("@BookName", ViewState["BookName"].ToString());

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        dataAdapter.Fill(data);
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Your data Was deleted ')</script>");
                    }

                }
                else
                {
                    lblbook.Text = "Invalid RRID or BBID";
                    lblbook.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        protected void Select_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Select_Student.SelectedValue))
            {
                return;
            }

            string qry = "select * from AddRent where SID=@SID and Status=@Status";
            using (SqlConnection connection = Class1.cn)
            using (SqlCommand command = new SqlCommand(qry, connection))
            {
                command.Parameters.AddWithValue("@SID", Select_Student.SelectedValue);
                command.Parameters.AddWithValue("@Status", "Yes");

                try
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);

                    Select_Book.DataSource = dataTable;
                    Select_Book.DataTextField = "BookName";
                    Select_Book.DataValueField = "RID";
                    Select_Book.DataBind();
                    Select_Book.Items.Insert(0, "SELECT");
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
