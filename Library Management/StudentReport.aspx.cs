using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
using System.Reflection.Emit;

namespace Library_Management
{
    public partial class StudentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void Btn_Branch_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 2)
            {
                ErrorMsg.Text = "Select Branch first";
            }
            else
            {
                string sql = "select * from Addstudent where Branch='" + DropDownList1.SelectedValue + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                lbl.Text = GridView1.Rows.Count.ToString() + "Student Found";
            }
        }
        protected void Btn_Name_Click(object sender, EventArgs e)
        {
            if (text_Search.Text == "")
            {
                ErrorMsg.Text = "Enter Student Name ";
            }
            else
            {
                string sql = "select * from Addstudent where StudentName='"+text_Search.Text+"'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                MultiView1.Visible = true;
                MultiView1.SetActiveView(View1);
                lbl.Text = GridView1.Rows.Count.ToString() + " Student Found";
            }
        }
        protected void Btn_View_Click(object sender, EventArgs e)
        {
            string sql = "select * from Addstudent where StudentName='" + text_Search.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Class1.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
            Stud_Id.Text = dt.Rows[0]["SID"].ToString();
            Stud_nm.Text = dt.Rows[0]["StudentName"].ToString();
            Stud_Branch.Text = dt.Rows[0]["Branch"].ToString();
            Stud_Mo.Text = dt.Rows[0]["Mobile"].ToString();
            Stud_Address.Text = dt.Rows[0]["Address"].ToString();
            Stud_City.Text = dt.Rows[0]["City"].ToString();
            Stud_Pin.Text = dt.Rows[0]["Pincode"].ToString();
            DateTime dobb = Convert.ToDateTime(dt.Rows[0]["Birthdate"].ToString());
            Stud_Date.Text = dobb.GetDateTimeFormats()[7].ToString();
            Stud_Email.Text = dt.Rows[0]["Email"].ToString();
        }
    }
}
