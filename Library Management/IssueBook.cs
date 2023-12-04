using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Library_Management;

public class IssueBook : Page
{
	protected HtmlForm form1;

	protected Button btn_logout;

	protected HiddenField HiddenField1;

	protected DropDownList DropDownList1;

	protected SqlDataSource SqlDataSource1;

	protected DropDownList DropDownList2;

	protected SqlDataSource SqlDataSource2;

	protected Label ErrorMsg;

	protected Button Select;

	protected MultiView MultiView1;

	protected View View1;

	protected Label BookId;

	protected Label Book_nm;

	protected System.Web.UI.WebControls.Image Image2;

	protected Label Book_Detail;

	protected Label Book_Author;

	protected Label Book_Publication;

	protected Label Book_Branch;

	protected Label Book_Price;

	protected Label Book_Quantity;

	protected Label Book_Available;

	protected Label lbldetail;

	protected Label lblissue;

	protected RangeValidator RangeValidator1;

	protected RangeValidator RangeValidator2;

	protected DropDownList text_branch;

	protected DropDownList text_student;

	protected SqlDataSource SqlDataSource3;

	protected TextBox text_days;

	protected Button Btn_Issue;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Select_Click(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedIndex == 0)
		{
			ErrorMsg.Text = "Select Publication";
			ErrorMsg.ForeColor = Color.Red;
			MultiView1.ActiveViewIndex = -1;
			return;
		}
		if (DropDownList2.SelectedIndex == 0)
		{
			ErrorMsg.Text = "Select Book";
			ErrorMsg.ForeColor = Color.Red;
			MultiView1.ActiveViewIndex = -1;
			return;
		}
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

	protected void Btn_Issue_Click(object sender, EventArgs e)
	{
	}

	protected void Select_Click1(object sender, EventArgs e)
	{
		if (DropDownList2.SelectedIndex == 9)
		{
			ErrorMsg.Text = "Select Publication";
			ErrorMsg.ForeColor = Color.Red;
			MultiView1.ActiveViewIndex = -1;
			return;
		}
		if (DropDownList1.SelectedIndex == 9)
		{
			ErrorMsg.Text = "Select Book";
			ErrorMsg.ForeColor = Color.Red;
			MultiView1.ActiveViewIndex = -1;
			return;
		}
		string sql = "select * from AddBook where Publication='" + DropDownList2.SelectedItem?.ToString() + "'";
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
