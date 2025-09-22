<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Shopping.Com.Cart"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: calibri">
    <form id="form1" runat="server">
        <div style="margin: 5px; border: solid 1pt wheat">
            <div style="height: 60px; color: white; background-color: cadetblue; padding: 3px; border: solid 1pt blue; text-align: center">
                <h2>Shop KA09</h2>
            </div>
        </div>

        <div style="padding: 3px; margin: 3px; display: flex">
            <div style="width: 40%; display: inline-block">
                Welcome :
                <asp:Label ID="lblUser" runat="server" Text="Guest"></asp:Label>
            </div>
            <div style="width: 40%; float: right; text-align: right">
                <h3>
                    <asp:Label ID="lblCat" runat="server" Text="" Style="font-weight: 700; color: #6600CC"></asp:Label>
                </h3>
            </div>
            <div style="width: 40%; float: right; text-align: right">
                <h3>
                    <asp:Label ID="Label2" runat="server" Text="Items in cart :  " Style="font-weight: 700; color: #6600CC"></asp:Label>
                    <asp:LinkButton ID="btnCart" runat="server">0</asp:LinkButton>
                </h3>
            </div>
            <div style="width: 40%; float: right; text-align: right">
    <h3>
        <asp:Label ID="Label3" runat="server" Text="Buy More Items" Style="font-weight: 700; color: #6600CC"></asp:Label>
        <asp:LinkButton ID="btnHome" runat="server" OnClick="btnHome_Click">Home</asp:LinkButton>
    </h3>
</div>
        </div>

        <hr style="border: solid 1pt blue" />
        <div>
            <div style="display: flex; margin: 10px">
                <div style="display: inline-block; width: 25%; padding: 3px; border: solid thin red; padding: 5px; margin: 2px">
                </div>
                <div style="width: 70%; float: right; clear: both; border: solid thin red; padding: 15px">

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="327px" Width="764px" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Vendor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantoty">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Convert.ToInt32(Eval("Quantity"))*Convert.ToDecimal(Eval("Price")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="More">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("Id") %>' Height="29px" ImageUrl="~/Images/plus.jpg" Width="33px" OnClick="ImageButton1_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Less">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("Id") %>' Height="33px" ImageUrl="~/Images/minus.png" Width="36px" OnClick="ImageButton2_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument='<%# Eval("Id") %>' Height="35px" ImageUrl="~/Images/remove.png" OnClick="ImageButton3_Click" OnClientClick="return confirm('Are you sure you want to remove this item from the Cart ? ');" Width="36px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>

                    <div style="margin-top:20px">
                        <h3>Total Cart Value : <asp:Label ID="lblCartValue" runat="server" Text="Label"></asp:Label></h3>
                    </div>
                     <div style="margin-top:20px">
     <h3>Proceed to Pay : <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Checkout</asp:LinkButton></h3>
 </div>
                </div>
            </div>
        </div>
        <hr />
        <div style="display: block; text-align: center">
            Copy Rights &copy; All Rights are reserved to Tech Novice Solutions &trade; , Mysore
        </div>

    </form>
</body>

</html>

