<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Shopping.Com.Products" %>

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
                    <asp:LinkButton ID="btnCart" runat="server" OnClick="btnCart_Click">0</asp:LinkButton>
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
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </div>
                <div style="width: 70%; float: right; clear: both; border: solid thin red; padding: 15px">

                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="327px" Width="764px" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer">
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("Vendor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add To Cart">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnAddToCart_Click">Add To Cart</asp:LinkButton>
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
