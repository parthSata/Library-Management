using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Library_Management
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    public class Image : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string roll_no = context.Request.QueryString["SID"].ToString();
            string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString();
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();
            string sTSQL = "select img from Images where SID=@SID";
            SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
            objCmd.CommandType = CommandType.Text;
            object data = objCmd.ExecuteScalar();
            objConn.Close();
            objCmd.Dispose();
            context.Response.BinaryWrite((byte[])data);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}