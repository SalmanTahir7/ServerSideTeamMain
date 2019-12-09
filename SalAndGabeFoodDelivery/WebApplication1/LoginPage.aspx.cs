using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using Classes;
using System.Data;
using System.Data.SqlClient;

namespace SalAndGabeFoodDelivery
{
    public partial class LoginPage : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand bigCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnCreateAcct_Click(object sender, EventArgs e)
        {
            regDiv.Visible = true;
            loginDiv.Visible = false;
            regRestDiv.Visible = false;
        }

        protected void btnCreateRestAcct_Click(object sender, EventArgs e)
        {
            regDiv.Visible = false;
            loginDiv.Visible = false;
            regRestDiv.Visible = true;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            regDiv.Visible = false;
            loginDiv.Visible = true;
            regRestDiv.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            regDiv.Visible = false;
            loginDiv.Visible = true;
            regRestDiv.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(IsValidLogin() == true)
            {
                SqlCommand sql = new SqlCommand("SELECT Email, Password FROM [TP_Users] WHERE Email = '" + txtUN.Text + "' AND Password = '" + txtPW.Text + "'", dBConnect.GetConnection());
                dBConnect.GetConnection().Open();
                SqlDataReader read = sql.ExecuteReader();

                if(read.Read() == true)
                {
                    string un = read["Email"].ToString();
                    string pw = read["Password"].ToString();

                    if(un != txtUN.Text && pw != txtPW.Text)
                    {
                        errorLBL.Visible = true;
                        read.Close();
                    }
                    else if(un == txtUN.Text && pw == txtPW.Text)
                    {
                        read.Close();
                        dBConnect.CloseConnection();
                        User user = new User();
                        SqlCommand sqlGet = new SqlCommand("SELECT * FROM [TP_Users] WHERE Email = '" + txtUN.Text + "' AND Password = '" + txtPW.Text + "'", dBConnect.GetConnection());
                        dBConnect.GetConnection().Open();
                        SqlDataReader getReader = sqlGet.ExecuteReader();

                        if (getReader.Read() == true)
                        {
                            user.LoginID = getReader["LoginID"].ToString();
                            user.Email = getReader["Email"].ToString();
                            user.Password = getReader["Password"].ToString();
                            user.UserType = getReader["UserType"].ToString();
                            user.Name = getReader["Name"].ToString();
                            user.Image = getReader["Image"].ToString();
                            user.Address = getReader["Address"].ToString();
                            user.BillingAddress = getReader["BillingAddress"].ToString();
                            user.PhoneNumber = getReader["PhoneNumber"].ToString();
                            user.MenuID = getReader["MenuID"].ToString();
                            user.ResturantType = getReader["ResturantType"].ToString();
                        }

                        if(user.UserType == "Customer")
                        {
                            getReader.Close();
                            Session["customer"] = user;
                            Session["userNameC"] = user.Name;
                            Session["LoginIDC"] = user.LoginID;
                            Server.Transfer("CustomerHome.aspx");
                        }
                        else if(user.UserType == "Resturant")
                        {
                            getReader.Close();
                            Session["resturant"] = user;
                            Session["userNameR"] = user.Name;
                            Session["LoginIDR"] = user.LoginID;
                            Server.Transfer("ResturantHome.aspx");
                        }

                    }
                }
            }
        }

        private bool IsValidLogin()
        {
            if (txtUN.Text == "")
            {
                errorLBL.Visible = true;
                txtUN.Text = "";
                txtPW.Text = "";
                txtUN.Focus();
                return false;
            }

            if (txtPW.Text == "")
            {
                errorLBL.Visible = true;
                txtUN.Text = "";
                txtPW.Text = "";
                txtUN.Focus();
                return false;
            }

            else
            {
                return true;
            }
        }

        protected void btnCreateCust_Click(object sender, EventArgs e)
        {
            int loginID = GenerateKey(3);
            int bankNo = GenerateKey(6);
            string userType = "Customer";
            User newUser = new User();
            newUser.LoginID = loginID.ToString();
            newUser.UserType = userType;
            newUser.Email = txtEmail.Text.ToString();
            newUser.Password = txtNewPW.Text.ToString();
            newUser.Name = txtCustName.Text.ToString();
            newUser.Address = txtDelAddy.Text.ToString();
            newUser.BillingAddress = txtBillAddy.Text.ToString();
            newUser.BankAccount = bankNo;


            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_NewCustomer";
            SqlParameter parm1 = new SqlParameter("@loginID", newUser.LoginID);
            SqlParameter param2 = new SqlParameter("@email", newUser.Email);
            SqlParameter param3 = new SqlParameter("@password", newUser.Password);
            SqlParameter param4 = new SqlParameter("@userType", newUser.UserType);
            SqlParameter param5 = new SqlParameter("@nameC", newUser.Name);
            SqlParameter param6 = new SqlParameter("@addy", newUser.Address);
            SqlParameter param7 = new SqlParameter("@billAddy", newUser.BillingAddress);
            SqlParameter param8 = new SqlParameter("@bankNo", newUser.BankAccount);

            parm1.Direction = ParameterDirection.Input;
            parm1.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(parm1);

            param2.Direction = ParameterDirection.Input;
            param2.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param2);

            param3.Direction = ParameterDirection.Input;
            param3.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param3);

            param4.Direction = ParameterDirection.Input;
            param4.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param4);

            param5.Direction = ParameterDirection.Input;
            param5.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param5);

            param6.Direction = ParameterDirection.Input;
            param6.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param6);

            param7.Direction = ParameterDirection.Input;
            param7.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param7);

            param8.Direction = ParameterDirection.Input;
            param8.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param8);

            dBConnect.DoUpdateUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();

            lblSuccessful1.Visible = true;
        }

        public int GenerateKey(int num)
        {
            int key;
            Random rand = new Random();
            string r = "";

            for (int i = 0; i < num; i++)
            {
                r += rand.Next(0, 9).ToString();
            }
            key = Convert.ToInt32(r);
            return key;
        }

        protected void btnCreateRest_Click(object sender, EventArgs e)
        {
            int loginID = GenerateKey(3);
            int menuID = GenerateKey(3);
            int bankNo = GenerateKey(6);
            string userType = "Resturant";
            User newUser = new User();
            newUser.LoginID = loginID.ToString();
            newUser.UserType = userType;
            newUser.Email = txtRestEmail.Text.ToString();
            newUser.Password = txtnewPWR.Text.ToString();
            newUser.Name = txtrestName.Text.ToString();
            newUser.Address = txtAddyRest.Text.ToString();
            newUser.Image = fileRestPic.ToString();
            newUser.PhoneNumber = txtPhoneNoRest.Text.ToString();
            newUser.MenuID = menuID.ToString();
            newUser.ResturantType = txtRestType.Text.ToString();
            newUser.BankAccount = bankNo;

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_NewResturant";
            SqlParameter parm1 = new SqlParameter("@loginID", newUser.LoginID);
            SqlParameter param2 = new SqlParameter("@email", newUser.Email);
            SqlParameter param3 = new SqlParameter("@password", newUser.Password);
            SqlParameter param4 = new SqlParameter("@userType", newUser.UserType);
            SqlParameter param5 = new SqlParameter("@nameR", newUser.Name);
            SqlParameter param6 = new SqlParameter("@addy", newUser.Address);
            SqlParameter param7 = new SqlParameter("@image", newUser.Image);
            SqlParameter param8 = new SqlParameter("@phoneNo", newUser.PhoneNumber);
            SqlParameter param9 = new SqlParameter("@menuID", newUser.MenuID);
            SqlParameter param10 = new SqlParameter("@restType", newUser.ResturantType);
            SqlParameter param11 = new SqlParameter("@bankNo", newUser.BankAccount);

            parm1.Direction = ParameterDirection.Input;
            parm1.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(parm1);

            param2.Direction = ParameterDirection.Input;
            param2.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param2);

            param3.Direction = ParameterDirection.Input;
            param3.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param3);

            param4.Direction = ParameterDirection.Input;
            param4.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param4);

            param5.Direction = ParameterDirection.Input;
            param5.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param5);

            param6.Direction = ParameterDirection.Input;
            param6.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param6);

            param7.Direction = ParameterDirection.Input;
            param7.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param7);

            param8.Direction = ParameterDirection.Input;
            param8.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param8);

            param9.Direction = ParameterDirection.Input;
            param9.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param9);

            param10.Direction = ParameterDirection.Input;
            param10.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param10);

            param11.Direction = ParameterDirection.Input;
            param11.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param11);

            dBConnect.DoUpdateUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();

            lblSuccessfulR.Visible = true;
        }
    }
}