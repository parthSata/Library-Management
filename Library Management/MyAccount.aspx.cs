﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection.Emit;


namespace Library_Management
{
    public partial class MyAccount : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Parth Sata\\Library Management\\Library Management\\App_Data\\Library Management.mdf\";Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View2);
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View3);
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            string sql = "update Addstudent SET [StudentName]='" + text_nm.Text + "',Branch='" + text_branch.SelectedValue + "',Gender='" + text_gender.SelectedValue + "',Birthdate='" + text_birthdate.Text + "',Mobile='" + text_mo.Text + "',Address='" + text_address.Text + "',City='" + text_city.Text + "',Pincode='" + text_pin.Text + "',Email='" + text_email.Text + "',Password='" + text_pass.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response.Write("updated");

        }
    }
}