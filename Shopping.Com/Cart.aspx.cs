using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Com
{
	public partial class Cart : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["cart"] != null)
			{
			List<Product> itemsIncart=(List<Product>)Session["cart"];
				lblCartValue.Text = GetTotalCartValue(itemsIncart).ToString();

                if (itemsIncart.Count>0)
				{
					GridView1.DataSource = itemsIncart;
					GridView1.DataBind();
				}
				else
				{
					btnCart.Text = "Your Cart is Empty";
				}
			}
		
		}

        protected void btnHome_Click(object sender, EventArgs e)
        {
			Response.Redirect("Home.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
			ImageButton btnRem=(ImageButton)sender;
			List<Product> productsPurchased=(List<Product>)Session["cart"];
			if (productsPurchased.Count > 0)
			{
				foreach (Product product in productsPurchased)
				{
					if (product.Id == Convert.ToInt32(btnRem.CommandArgument))
					{
						productsPurchased.Remove(product);
						Session["cart"] = productsPurchased;

						if (productsPurchased.Count > 0)
						{
							GridView1.DataSource = productsPurchased;
							GridView1.DataBind();
                            lblCartValue.Text = GetTotalCartValue(productsPurchased).ToString();
                            break;
						}
						else
						{
							btnCart.Text = "Your Cart is Empty";
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                            lblCartValue.Text = GetTotalCartValue(productsPurchased).ToString();
                            break;
						}

					}
				}
			}
			else
			{
				GridView1.DataSource = null;
				GridView1.DataBind();
                btnCart.Text = "Your Cart is Empty";
				lblCartValue.Text = "0.0 INR";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnAdd = (ImageButton)sender;
            List<Product> productsPurchased = (List<Product>)Session["cart"];
			foreach (Product product in productsPurchased)
			{
				if(product.Id==Convert.ToInt32(btnAdd.CommandArgument))
				{
					product.Quantity = product.Quantity + 1;
					Session["cart"] = productsPurchased;
					GridView1.DataSource = productsPurchased;
					GridView1.DataBind();
					lblCartValue.Text = GetTotalCartValue(productsPurchased).ToString();

                    break;

				}
			}
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnAdd = (ImageButton)sender;
            List<Product> productsPurchased = (List<Product>)Session["cart"];
            foreach (Product product in productsPurchased)
            {
                if (product.Id == Convert.ToInt32(btnAdd.CommandArgument))
                {
					if (product.Quantity == 1)
					{
						productsPurchased.Remove(product);
					}
					else
					{
						product.Quantity = product.Quantity - 1;
					}
                    Session["cart"] = productsPurchased;
                    GridView1.DataSource = productsPurchased;
                    GridView1.DataBind();
                    lblCartValue.Text = GetTotalCartValue(productsPurchased).ToString();
                    break;

                }
            }

        }

		Decimal GetTotalCartValue(List<Product> products)
		{
			Decimal cartValue	 = 0;
			foreach (Product product in products)
			{
				cartValue += product.Quantity * product.Price;
			}
			return cartValue;
			
		}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
			Response.Redirect("Payments.aspx");
        }
    }
    }
