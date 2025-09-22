using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
namespace Shopping.Com
{
	public partial class Products : System.Web.UI.Page
	{
		SqlConnection con = new SqlConnection();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["category"] != null)
			{
				con.ConnectionString = WebConfigurationManager.ConnectionStrings["connectShop"].ToString();
				lblCat.Text = Request.QueryString["category"].ToString();

				//Display the Products of the selected Category
				GridView1.DataSource = ListProducts(Convert.ToInt32(Request.QueryString["catid"]));
				GridView1.DataBind();
				OutOfStock();
                // List the vendors of the selected category
                if (!IsPostBack)
				{
                    CheckBoxList1.DataSource = ListVendors(Convert.ToInt32(Request.QueryString["catid"]));
                    CheckBoxList1.DataTextField = "Vendor";
                    CheckBoxList1.DataValueField = "Vendorid";
                    CheckBoxList1.DataBind();
                }
				// Add  cart to session if not present
				if (Session["cart"]==null)
				{
					Session["cart"] = new List<Product>();
				}
				else
				{
                    List<Product> products = (List<Product>)Session["cart"];
					if(products.Count>0)
					{
						btnCart.Text = GetCartItemCount().ToString();
					}
                }
			}
			else
			{
				Response.Redirect("Home.aspx");
			}
		}
		DataTable ListProducts(int catId)
		{
			SqlDataAdapter daProds = new SqlDataAdapter("Select Pid as [Id], Product, Price, v.Vendor, P.Quantity from ProductMaster p inner join Vendors v on v.VendorId=p.VendorId where p.catid=" + catId, con);
			DataTable products = new DataTable();
			daProds.Fill(products);
			return products;
		}
		DataTable ListVendors(int catId)
		{
			DataTable dtVendors = new DataTable();
			SqlDataAdapter daVendors = new SqlDataAdapter("Select * from Vendors where vendorid in (Select vendorid from ProductMaster where catid=" + catId + ")", con);
			daVendors.Fill(dtVendors);
			return dtVendors;
		}

		void OutOfStock()
		{
			DataTable dt = (DataTable)GridView1.DataSource;
			for (int i = 0; i < dt.Rows.Count; i++)
			{

				if (Convert.ToInt32(dt.Rows[i][4]) == 0)
				{
					LinkButton btnAdd = (LinkButton)GridView1.Rows[i].FindControl("btnAddToCart");
					btnAdd.Text = "Out of Stock";
					btnAdd.Enabled = false;
				}
			}
		}

		protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string vendorId = "";
			foreach (ListItem cb in CheckBoxList1.Items)
			{
				if (cb.Selected)
				{
					vendorId = vendorId + cb.Value.ToString() + ",";
				}
			}

			if (vendorId.Length > 0)
			{
				SqlDataAdapter daProds = new SqlDataAdapter("Select Pid as [Id], Product, Price, v.Vendor, P.Quantity from ProductMaster p inner join Vendors v on v.VendorId=p.VendorId where p.quantity>0 and p.catid=" + Convert.ToInt32(Request.QueryString["catId"]) + " and p.vendorid in (" + vendorId.Remove(vendorId.LastIndexOf(",")) + ")", con);
				DataTable products = new DataTable();
				daProds.Fill(products);
				GridView1.DataSource = products;
				GridView1.DataBind();
			}
			else
			{
				SqlDataAdapter daProds = new SqlDataAdapter("Select Pid as [Id], Product, Price, v.Vendor, P.Quantity from ProductMaster p inner join Vendors v on v.VendorId=p.VendorId where p.quantity>0 and p.catid=" + Convert.ToInt32(Request.QueryString["catId"]), con);
				DataTable products = new DataTable();
				daProds.Fill(products);
				GridView1.DataSource = products;
				GridView1.DataBind();
			}
		}

		protected void btnAddToCart_Click(object sender, EventArgs e)
		{
			LinkButton btnAdd = (LinkButton)sender;
			List<Product> products = (List<Product>)Session["cart"];
			int productId= Convert.ToInt32(btnAdd.CommandArgument);
			//check for the availability of the product in the cart
			if (products.Count > 0)
			{
				foreach (Product p in products)
				{
					if (p.Id == productId)
					{
						p.Quantity = p.Quantity + 1;
                        Session["cart"] = products;
                        btnCart.Text = GetCartItemCount().ToString();
                        return;
					}
				}
			}
			
				// adding
				Product product = new Product();
				product.Id = productId;
				GridViewRow rowSelected = (GridViewRow)btnAdd.Parent.Parent;
				product.ProductName = ((Label)rowSelected.FindControl("lblProduct")).Text;
				product.Price = Convert.ToDecimal(((Label)rowSelected.FindControl("lblPrice")).Text);
				product.Vendor = ((Label)rowSelected.FindControl("lblVendor")).Text;
				product.Quantity = 1;
				products.Add(product);
			
			Session["cart"] = products;
			btnCart.Text = GetCartItemCount().ToString();

        }

		int GetCartItemCount()
		{
			int count = 0;
            List<Product> products = (List<Product>)Session["cart"];
			foreach (Product p in products)
			{
				count = count + p.Quantity;
			}
			return count;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
			Response.Redirect("Home.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
			Response.Redirect("Cart.aspx");
        }
    }
}