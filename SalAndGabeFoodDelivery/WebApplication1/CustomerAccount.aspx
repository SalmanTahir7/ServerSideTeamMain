<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAccount.aspx.cs" Inherits="WebApplication1.CustomerAccount" %>

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
                    <asp:Label runat="server">Sal & Gabe's Food Service!</asp:Label>
                </div>
                <div class="col-sm-2"></div>
            </div>
            

            <div class="row" id="menuRow">
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="custName"></asp:Label>
                </div>
                <div class="col-sm-3"></div>
                <div class="col-sm-3">
                    <asp:Button runat="server" ID="btnResturants" Text="View Resturants" />
                </div>
                <div class="col-sm-3">
                    <asp:Button runat="server" ID="btnOrder" Text="View Order"/>
                </div>
            </div>


            <br /><br />
            <div id="infoDiv" runat="server">
            <asp:Label ID="lblAcct" runat="server">Update your Account Information Here! Click the "Edit Info" Button to edit.</asp:Label>
                <br />

                <div class="row" runat="server">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <asp:GridView ID="gvCustInfo" runat="server" AutoGenerateColumns="False" Height="57px" Width="942px">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="BillingAddress" HeaderText="Billing Address" />
                </Columns>
            </asp:GridView>
                    </div>
                    <div class="col-sm-2"></div>

                </div>
                <br />
                <div class="row">
                    <div class="col-sm-5"></div>
                    <div class="col-sm-2">
                         <asp:Button id="btnEditInfo" runat="server" Text="Edit Info" OnClick="btnEditInfo_Click" />
                    </div>
                    <div class="col-sm-5"></div>
                </div>
           
            </div>

            <div id="divAcctSet" runat="server" visible="false">
                
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Customer Name: </asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"></div>
                     </div>
                
                <br />
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Email: </asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"></div>
                </div>

                <br />
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Delivery Address: </asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDelAddy" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"></div>
                </div>

                <br />
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Billing Address: </asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtBillAddy" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"></div>
                </div>

                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Password: </asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"></div>
                </div>

                <div class="row" id="btnzz">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Account" OnClick="btnUpdate_Click" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Button ID="btnPayments" runat="server" Text="Update Payments" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Button ID="btnViewOrders" runat="server" Text="View Orders" />
                    </div>
                  </div>
                </div>

            <div id="paymentsDiv" runat="server">


                ******************UPDATE PAYMENT INFO HERE***********


            </div>


            <div id="divMyOrders" runat="server" visible="false">

                <asp:GridView ID="gvMyOrders" runat="server" AutoGenerateColumns="false">

                </asp:GridView>

            </div>




           

        </div>
    </form>
</body>
</html>
