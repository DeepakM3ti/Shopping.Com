using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shopping.Com
{
	public partial class Payments : System.Web.UI.Page
	{
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
		{
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["connectShop"].ToString();
            if (Session["isUserLoggedIn"]==null || Convert.ToBoolean(Session["isUserLoggedIn"]) ==false)
            {
                Response.Redirect("Home.aspx?source=Payments");
            }
            else
            {
                lblUser.Text = Session["customer"].ToString();
                lblAddress.Text = Session["addr"].ToString();
            }
            if (Session["cart"] != null)
            {
                GridView1.DataSource = (List<Product>)Session["cart"];
                GridView1.DataBind();
                lblCartValue.Text = GetTotalCartValue((List<Product>)Session["cart"]).ToString();
            }
		}

        Decimal GetTotalCartValue(List<Product> products)
        {
            Decimal cartValue = 0;
            foreach (Product product in products)
            {
                cartValue += product.Quantity * product.Price;
            }
            return cartValue;

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btnPayments_Click(object sender, EventArgs e)
        {
            int paymentId = -1;
            foreach(ListItem li in RadioButtonList1.Items)
            {
                if(li.Selected)
                {
                    paymentId = Convert.ToInt16(li.Value);
                }
            }
            if (paymentId > -1)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction trans = con.BeginTransaction();
                SqlCommand cmdBillId = new SqlCommand("Select max(billid)+1 from Billmaster",con);
                cmdBillId.Transaction = trans;

               int BillId=Convert.ToInt32(cmdBillId.ExecuteScalar());

                SqlCommand generateBill = new SqlCommand();
                generateBill.Transaction = trans;
                generateBill.Connection = con;

                generateBill.CommandText = "insert into billmaster values(" + BillId + "," + Convert.ToInt32(Session["custId"])+", getdate(),"+ paymentId + ")";
                SqlCommand cmdSales = new SqlCommand("insert into sales values (@pid, @qty, @billId)",con);
                SqlParameter paramBillId = new SqlParameter("@billId", SqlDbType.Int);
                SqlParameter paramPid = new SqlParameter("@pid", SqlDbType.Int);
                SqlParameter paramQuantity = new SqlParameter("@qty", SqlDbType.Int);

                cmdSales.Parameters.Add(paramBillId);
                cmdSales.Parameters.Add(paramPid);
                cmdSales.Parameters.Add(paramQuantity);


                cmdSales.Transaction = trans;

                SqlCommand cmdUpdatePrducts = new SqlCommand();
                cmdUpdatePrducts.Transaction = trans;
                cmdUpdatePrducts.Connection = con;
                cmdUpdatePrducts.CommandText = "update productmaster set quantity=quantity-@qty where pid=@pid";
                SqlParameter paramQty = new SqlParameter("@qty", SqlDbType.Int);
                SqlParameter paramProId = new SqlParameter("@pid", SqlDbType.Int);
                cmdUpdatePrducts.Parameters.Add(paramQty);
                cmdUpdatePrducts.Parameters.Add(paramProId);

                try
                {
                    generateBill.ExecuteNonQuery();
                    foreach(Product p in (List<Product>)Session["cart"])
                    {
                        paramBillId.Value = BillId;
                        paramPid.Value = p.Id;
                        paramQuantity.Value= p.Quantity;
                        cmdSales.ExecuteNonQuery();

                        paramQty.Value = p.Quantity;
                        paramProId.Value = p.Id;
                        cmdUpdatePrducts.ExecuteNonQuery();

                    }
                    trans.Commit();
                    lblSalesMsg.Text = "Your Order is sucesfully Placed";
                    lblSalesMsg.ForeColor = System.Drawing.Color.Green;
                    btnPayments.Enabled = false;
                    Session.Remove("cart");
                }
                catch
                {
                    trans.Rollback();
                    lblSalesMsg.Text = "Your Order has been declined";
                    lblSalesMsg.ForeColor = System.Drawing.Color.Red;

                }





            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "Payments","alert('Choose one of the payment options')",true);
            }
        }
    }
}