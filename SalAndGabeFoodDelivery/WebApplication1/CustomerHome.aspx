<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="WebApplication1.CustomerHome" %>

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
                    <asp:Label runat="server" ID="lblCustName"></asp:Label>
                </div>
                <div class="col-sm-3"></div>
                <div class="col-sm-3"></div>
                <div class="col-sm-3">
                    <asp:Button runat="server" ID="btnAccount" Text="Account" OnClick="btnAccount_Click" />
                </div>
            </div>

            <div id="restDiv" runat="server">
                <div class="row" id="rowBrows">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <asp:Label runat="server" ID="lblBrowse">Browse & Search Resturants!</asp:Label>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
                <br /><br />
                <div class="row" id="searchDiv" runat="server">
                    <div class="col-sm-1"></div>
                    <div class="col-sm-4">
                        <asp:Label runat="server">Search by Name:</asp:Label>
                        <asp:TextBox ID="txtRestName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnRestName" runat="server" Text="Search" OnClick="btnRestName_Click"/>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label runat="server">Search by Type:</asp:Label>
                        <asp:TextBox ID="txtRestType" runat="server">Ex: Mexican</asp:TextBox>
                        <asp:Button ID="btnRestType" runat="server" Text="Search" OnClick="btnRestType_Click"/>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnAll" runat="server" Text="View All Resturants" OnClick="btnAll_Click" visible="false"/>
                    </div>
                    <div class="col-sm-1"></div>
                &nbsp;</div>
                
                <br />
                <div id="divRestur" runat="server">
                    <asp:GridView ID="gvResturants" runat="server" AutoGenerateColumns="False" Height="16px" Width="769px">
                    <Columns>
                        <asp:TemplateField HeaderText="Choose your Resturant!">
                             <ItemTemplate>
                                 <asp:CheckBox ID="chxSelect" runat="server" />
                             </ItemTemplate>
                         </asp:TemplateField>
                        <asp:ImageField DataImageUrlField ="Image">
                            <ItemStyle Height="50px" Width="50px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Name" HeaderText="Resturant" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone #" />
                        <asp:BoundField DataField="ResturantType" HeaderText="Cusiene" />
                    </Columns>
                </asp:GridView>
                    <asp:Button ID="btnViewMenu" runat="server" Text="View Menu" OnClick="btnViewMenu_Click" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Visible="false">Please select only one resturant to order from!</asp:Label>
                </div>
                

                

                <div id="menuDiv" runat="server" visible="false">

                    <asp:Label ID="lblOrderFrom" runat="server"></asp:Label>
                    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Add to your order!">
                             <ItemTemplate>
                                 <asp:CheckBox ID="chxSelect" runat="server" />
                             </ItemTemplate>
                         </asp:TemplateField>
                            <asp:ImageField DataImageUrlField ="Images"></asp:ImageField>
                            <asp:BoundField DataField="FoodType" />
                            <asp:BoundField DataField="Title"/>
                            <asp:BoundField DataField="Description" headertext="Description"/>
                            <asp:BoundField DataField="Price" headertext="Price"/>
                            <asp:TemplateField HeaderText="Options">
                                <ItemTemplate>
                                    <asp:TextBox runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MenuID" Visible="false" />
                            <asp:BoundField DataField="ItemID" Visible="false" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <div class="row" id="btnz">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-3">
                            <asp:Button ID="btnBack" runat="server" Text="Back to Resturants" OnClick="btnBack_Click" />
                        </div>
                        <div class="col-sm-3">
                            <asp:Button ID="btnAddToOrder" runat="server" Text="Add to Order" OnClick="btnAddToOrder_Click"/>
                        </div>
                        <div class="col-sm-3">
                        <asp:Button runat="server" ID="btnOrder" Text="View Order" OnClick="btnOrder_Click"/>
                        </div>
                    </div>
                    <br /><br />
                </div>

                <div id="divOrderSubmit" runat="server" visible="false">
                    <div class="row" runat="server">
                       
                        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False">
                            <Columns>
                             <asp:TemplateField HeaderText="View to your order!">
                             <ItemTemplate>
                                 <asp:CheckBox ID="chxSelect" runat="server" />
                             </ItemTemplate>
                         </asp:TemplateField>
                                <asp:BoundField DataField="OrderID" HeaderText="OrderID"/>
                                <asp:BoundField DataField="Status" HeaderText="Status"/>
                                <asp:BoundField DataField="DateTime" HeaderText="Date/Time"/>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnOrderS2" runat="server" Text="View Order" />

                    </div>
                </div>
            </div>


        </div>
    </form>
</body>
</html>
