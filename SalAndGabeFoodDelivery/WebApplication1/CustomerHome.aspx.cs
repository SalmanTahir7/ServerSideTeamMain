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
namespace WebApplication1
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand bigCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserName();

                User user = new User();
                user.UserType = "Resturant";
                
                
                bigCommand.CommandType = CommandType.StoredProcedure;
                bigCommand.CommandText = "TP_AllResturants";
                SqlParameter param = new SqlParameter("@typeUser", user.UserType);
                param.Size = 50;

                param.Direction = ParameterDirection.Input;
                param.SqlDbType = SqlDbType.VarChar;
                bigCommand.Parameters.Add(param);
                DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

                gvResturants.DataSource = dataSet;
                gvResturants.DataBind();
            }
        }

        //Shows menu of selected resturant
        protected void btnViewMenu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvResturants.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)gvResturants.Rows[i].FindControl("chxSelect");
                if (cbox.Checked)
                {
                    string restMenu = gvResturants.Rows[i].Cells[1].Text;

                    RestMenu menu = new RestMenu();
                    menu.Name = restMenu;
                    

                    bigCommand.CommandType = CommandType.StoredProcedure;
                    bigCommand.CommandText = "TP_MenuBuilder";
                    SqlParameter param = new SqlParameter("@restName", menu.Name);
                    param.Size = 50;

                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.VarChar;
                    bigCommand.Parameters.Add(param);
                    DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

                    gvMenu.DataSource = dataSet;
                    gvMenu.DataBind();

                    lblOrderFrom.Text = "Order From " + restMenu + "!";

                    searchDiv.Visible = false;
                    menuDiv.Visible = true;
                    divRestur.Visible = false;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            menuDiv.Visible = false;
            divRestur.Visible = true;
            searchDiv.Visible = true;
        }

        //Gets current user's name to display at the top of the page
        private void getUserName()
        {
            string nameCust = "";
            string emailName = (string)Session["userNameC"];
            SqlCommand comm = new SqlCommand("SELECT Name FROM [TP_Users] WHERE Name = '" + emailName + "'", dBConnect.GetConnection());
            dBConnect.GetConnection().Open();
            SqlDataReader dataRead = comm.ExecuteReader();

            while (dataRead.Read())
            {
                nameCust = dataRead["Name"].ToString();
                lblCustName.Text = "Welcome back, " + nameCust + "!";
            }
            dataRead.Close();
            dBConnect.CloseConnection();
        }

        //Search by name
        protected void btnRestName_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = txtRestName.Text.ToString();

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_SearchName";
            SqlParameter param = new SqlParameter("@restName", user.Name);
            param.Size = 50;

            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param);
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            btnAll.Visible = true;
            gvResturants.DataSource = dataSet;
            gvResturants.DataBind();
        }


        //Search by type
        protected void btnRestType_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.ResturantType = txtRestType.Text.ToString();

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_SearchType";
            SqlParameter param = new SqlParameter("@restType", user.ResturantType);
            param.Size = 50;

            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param);
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            btnAll.Visible = true;
            gvResturants.DataSource = dataSet;
            gvResturants.DataBind();
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserType = "Resturant";


            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_AllResturants";
            SqlParameter param = new SqlParameter("@typeUser", user.UserType);
            param.Size = 50;

            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param);
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            gvResturants.DataSource = dataSet;
            gvResturants.DataBind();

            btnAll.Visible = false;
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccount.aspx");
            //Server.TransferRequest("CustomerAccount.aspx");
        }
    }
}