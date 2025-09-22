using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Diagnostics.Eventing.Reader;
namespace Shopping.Com
{
	public partial class Home : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection();
		protected void Page_Load(object sender, EventArgs e)
		{
			con.ConnectionString = WebConfigurationManager.ConnectionStrings["connectShop"].ToString();
			if(!IsPostBack)
			{
				DataList1.DataSource = ListCategories();
				DataList1.DataBind();
			}
		}
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

			Response.Redirect("Products.aspx");
        }
		DataTable ListCategories()
		{
			DataTable dtCategories = new DataTable();
			SqlDataAdapter daCat = new SqlDataAdapter("Select Catid, Category,'~/Images/'+category+'.jpg' as [ImgUrl] from CategoryList",con);
			daCat.Fill(dtCategories);
			return dtCategories;
		}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
			LinkButton btnClicked=(LinkButton)sender;
			int selectedCatid = Convert.ToInt32(btnClicked.CommandArgument);
			Response.Redirect("Products.aspx?catid="+selectedCatid+"&category="+btnClicked.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			//Login
			SqlCommand cmdLogin = new SqlCommand("Select cid, name, password, Address from CUstomers where email='"+txtEmail.Text.Trim()+"'",con);
			if (con.State == ConnectionState.Closed)
				con.Open();
			SqlDataReader dr=cmdLogin.ExecuteReader();
			if (dr.HasRows)
			{
				dr.Read();
				if (dr[2].ToString().Equals(txtPassword.Text.Trim()))
				{
					Session["custId"] = dr[0].ToString();
					Session["customer"] = dr[1].ToString();
					Session["isUserLoggedIn"]= true;
					Session["addr"]= dr[3].ToString();
					lblUser.Text = dr[1].ToString();
					if (Request.QueryString["source"]!=null)
					{
						Response.Redirect("Payments.aspx");
					}
				}
				else
				{
					lblMsg.Text = "Login Failed";
				}
			}
            
			else
			{
				lblMsg.Text = "Login Failed";
			}
			
        }
    }
}