<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SalAndGabeFoodDelivery.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sal & Gabe's</title>
         <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
         <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="LoginStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="row" id="headRow">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <asp:Label runat="server">Welcome to Sal & Gabe's Food Service!</asp:Label>
                </div>
                <div class="col-sm-4"></div>
            </div>
            

            <br /><br /><br /><br />
            <div id="loginDiv" runat="server">
                <div class="row" id="introRow">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblLogin" runat="server">Please enter your login credentials:</asp:Label><br />
                    </div>
                    <div class="col-sm-4"></div>
                </div>
                <br />
                <div class="row" id="row1">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblUN" runat="server">Email Address: </asp:Label><br />
                        <asp:TextBox ID="txtUN" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblPW" runat="server">Password: </asp:Label><br />
                        <asp:TextBox ID="txtPW" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
                <br />
                <div class="row" id="loginBtnRow">
                    <div class="col-sm-5"></div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                    <div class="col-sm-5"></div>
                </div>
                <div class="row" runat="server">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <asp:Label ID="errorLBL" runat="server" Visible="false">Please enter valid Login credentials!</asp:Label>
                    </div>
                    <div class="col-sm-4"></div>

                </div>
                

                <br />
                <br />

                <div class="row" id="roww">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <asp:Label ID="lblNoAcct" runat="server">Don't have an account yet? Click the appropriate button below to sign up!</asp:Label><br />
                    </div>
                    <div class="col-sm-2"></div>

                </div>
               
                
                <div class="row" id="row3">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnCreateAcct" runat="server" Text="Customer Account" Width="154px" OnClick="btnCreateAcct_Click" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnCreateRestAcct" runat="server" Text="Resturant Account" Width="154px" OnClick="btnCreateRestAcct_Click" />
                    </div>
                    <div class="col-sm-2"></div>
                </div>
               <br /><br />
            </div>

            <div id="regDiv" runat="server" visible="false">
                <asp:Label ID="lblPlease" runat="server">Please fill out all fields to create a customer account:</asp:Label><br /><br />

                <div class="row" id="row4">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblEmail" runat="server">Email (will serve as login name): </asp:Label><br />
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblNewPW" runat="server">Password: </asp:Label><br />
                        <asp:TextBox ID="txtNewPW" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
                
                <div class="row" id="row5">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblDelAddy" runat="server">Delivery Address: </asp:Label><br />
                        <asp:TextBox ID="txtDelAddy" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                         <asp:Label ID="lblBillAddy" runat="server">Billing Address: </asp:Label><br />
                         <asp:TextBox ID="txtBillAddy" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
                
                
               <div class="row" id="row6">
                   <div class="col-sm-2"></div>
                   <div class="col-sm-4">
                       <asp:Label ID="lblCustName" runat="server">Name: </asp:Label><br />
                       <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                   </div>
                   <div class="col-sm-6"></div>
               </div>
                <br />
                <asp:Label ID="lblCookie" runat="server">Check this box if you would like your Username to be saved for faster logins: </asp:Label>
                <asp:CheckBox ID="chxSaveUN" runat="server" />
                <br />
                <br />
                <div class="row" id="rowbtns">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnCreateCust" runat="server" Text="Create Account" OnClick="btnCreateCust_Click" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnBack2" runat="server" Text="Back to Login" OnClick="btnBack2_Click" />
                    </div>
                    <div class="col-sm-2"></div>
                </div>

                <asp:Label ID="lblSuccessful1" runat="server" Visible="false">Thanks for joining us! Your account has successfully been created! Go back to the Login page to sign in. </asp:Label> 
                
                

                <br /><br />
            </div>

            <div id="regRestDiv" runat="server" visible="false">
                <asp:Label ID="lblPlease2" runat="server">Please fill out all fields to create a resturant account:</asp:Label><br /><br />
                
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2">
                        <asp:Label ID="lblRestName" runat="server">Resturant Name: </asp:Label><br />
                        <asp:TextBox ID="txtrestName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-8"></div>


                </div>
                
                <div class="row" id="rowrest">
                    <div class="col-sm-1"></div>
                    <div class="col-sm-5">
                        
                        <asp:label runat="server">Email Address (will serve as login name): </asp:label><br />
                        <asp:TextBox ID="txtRestEmail" runat="server"></asp:TextBox>                        
                    </div>
                    <div class="col-sm-5">
                        
                        <asp:Label ID="lblPwRest" runat="server">Password: </asp:Label>
                        <asp:TextBox ID="txtnewPWR" runat="server"></asp:TextBox>                        
                    </div>
                    <div class="col-sm-1"></div>
                </div>
                <br />

                <div class="row" id="rowcontacts">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:label runat="server">Address: </asp:label><br />
                        <asp:TextBox ID="txtAddyRest" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:label runat="server">Phone Number: </asp:label><br />
                <asp:TextBox ID="txtPhoneNoRest" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
                <br />
                <div class="row" id="rowYeah">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Label runat="server">Type of Resturant:</asp:Label>
                        <asp:TextBox ID="txtRestType" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblPhoto" runat="server">Logo / photo of your resturant:</asp:Label><br />
                        <asp:FileUpload ID="fileRestPic" runat="server" />
                        
                    </div>
                    <div class="col-sm-2"></div>
                </div>

                <br />
                <div class="row" id="rowbtns2">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnCreateRest" runat="server" Text="Create Account" OnClick="btnCreateRest_Click" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnBack" runat="server" Text="Back to Login" OnClick="btnBack_Click" />
                    </div>
                    <div class="col-sm-2"></div>
                </div>

                <asp:Label ID="lblSuccessfulR" runat="server" Visible="false">Thanks for joining us! Your account has successfully been created! Go back to the Login page to sign in. </asp:Label> 
                
                
                <br />
            </div>
        </div>
    </form>
</body>
</html>
