﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOut.aspx");

        }
    }
}