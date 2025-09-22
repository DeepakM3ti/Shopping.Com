<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Shopping.Com.Home" %>

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
            <div style="padding: 3px; margin: 3px;">
                Welcome :
                <asp:Label ID="lblUser" runat="server" Text="Guest"></asp:Label>
            </div>
            <hr style="border: solid 1pt blue" />
            <div style="display: flex; margin: 10px">
                <div style="display: inline-block; width: 70%; padding: 3px; border: solid thin wheat; padding: 5px; margin: 2px">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="4">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("CatId") %>' Height="179px" ImageUrl='<%# Eval("ImgUrl") %>' OnClick="ImageButton1_Click" Width="178px" />
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CatId") %>' OnClick="LinkButton1_Click" Text='<%# Eval("Category") %>'></asp:LinkButton>
                        </ItemTemplate>

                    </asp:DataList>
                </div>
                <div style="width: 25%; float: right; clear: both; border: solid thin wheat; padding: 5px">
                    <div style="height: 30px; background-color: blue; color: white; margin: 1px; text-align: center">
                        <h3>Login</h3>
                    </div>
                    <div style="margin: 1px">
                        <div style="margin-top:5px">
                            <div>Email Id</div>
                            <div>
                                <asp:TextBox ID="txtEmail" runat="server" Height="25px" Width="200px">
                                        
                                </asp:TextBox>
                            </div>
                        </div>
                        <div style="margin-top:5px">
                            <div>Password</div>
                            <div>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Height="25px" Width="200px"></asp:TextBox>
                            </div>
                        </div>
                        <div style="margin-top:10px">
                            <div>
                                <asp:Button ID="Button1" runat="server" Text="Login" Height="30px" Width="200px" OnClick="Button1_Click" />
                            </div>
                        </div>
                    <div style="margin-top:15px">
                        <div>
                            <asp:Label ID="lblMsg" runat="server" Text="invalid Login" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div style="display: block; text-align: center">
            Copy Rights &copy; All Rights are reserved to Tech Novice Solutions &trade; , Mysore
        </div>
        </div>
    </form>
</body>
</html>
