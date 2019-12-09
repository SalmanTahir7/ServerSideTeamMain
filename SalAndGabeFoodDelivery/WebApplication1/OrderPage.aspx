<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="WebApplication1.OrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sal & Gabe's</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
         <link rel="stylesheet" href="CustomerStyles.css" />
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
         <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="row" id="headRow">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <asp:Label runat="server">Sal & Gabe's Food Service</asp:Label>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <br /><br />

            <div class="row" id="menuRow">
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="custName"></asp:Label>
                </div>
                <div class="col-sm-3"></div>
                <div class="col-sm-3">
                    <asp:Button ID="btnResturants" runat="server" Text="View Resturants"/>
                </div>
                <div class="col-sm-3">
                    <asp:Button runat="server" ID="btnAccount" Text="Account" />
                </div>
            </div>
            <br /><br />

            <div id="orderDiv" runat="server">
                <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Image" />
                        <asp:BoundField DataField="Title" />
                        <asp:BoundField DataField="Description" />
                        <asp:BoundField DataField="Price" />
                        <asp:CheckBoxField Text="Remove Item" />
                    </Columns>
                </asp:GridView>
                <br />
                <div class="row" id="btns">
                    <div class="col-sm-4">
                        <asp:Button ID="btnRemove" runat="server" Text="Remove Items" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnClear" runat="server" Text="Clear Order" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnPlace" runat="server" Text="Place Order" />
                    </div>

                </div>
            </div>
            


        </div>
    </form>
</body>
</html>
