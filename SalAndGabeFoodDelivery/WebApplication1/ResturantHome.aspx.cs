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
    public partial class ResturantHome : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand bigCommand = new SqlCommand();
        public static string itemid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getUserName();

                RestMenu menu = new RestMenu();
                menu.Name = Session["userNameR"].ToString();


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
                btnMenu.Visible = false;
            }
        }

        protected void btnAcctInfo_Click(object sender, EventArgs e)
        {
            divMenu.Visible = false;
            User user = new User();
            string custName = (string)Session["userNameR"];
            user.Name = custName;



            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_EditRest";
            SqlParameter param = new SqlParameter("@restName", user.Name);
            param.Size = 50;

            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param);
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            gvRestInfo.DataSource = dataSet;
            gvRestInfo.DataBind();

            infoDiv.Visible = true;
        }

        protected void btnEditRInfo_Click(object sender, EventArgs e)
        {
            txtRestName.Text = gvRestInfo.Rows[0].Cells[0].Text;
            txtRestEmail.Text = gvRestInfo.Rows[0].Cells[1].Text;
            txtRestPassword.Text = gvRestInfo.Rows[0].Cells[2].Text;
            txtRestAddy.Text = gvRestInfo.Rows[0].Cells[4].Text;
            txtRestPhoneNo.Text = gvRestInfo.Rows[0].Cells[5].Text;
            txtRestType.Text = gvRestInfo.Rows[0].Cells[6].Text;

            divUpdateAcctR.Visible = true;
            infoDiv.Visible = false;

        }

        protected void btnSaveAcct_Click(object sender, EventArgs e)
        {
            string restName = txtRestName.Text;
            string restEmail = txtRestEmail.Text;
            string restPassword = txtRestPassword.Text;
            string restAddy = txtRestAddy.Text;
            string restPhoneNo = txtRestPhoneNo.Text;
            string restType = txtRestType.Text;
            string loginID = Session["LoginIDR"].ToString();

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_UpdateResturant";

            SqlParameter param = new SqlParameter("@loginID", loginID);
            SqlParameter param1 = new SqlParameter("@restName", restName);
            SqlParameter param2 = new SqlParameter("@restPassword", restPassword);
            SqlParameter param3 = new SqlParameter("@restAddy", restAddy);
            SqlParameter param4 = new SqlParameter("@restPhoneNo", restPhoneNo);
            SqlParameter param5 = new SqlParameter("@restEmail", restEmail);
            SqlParameter param6 = new SqlParameter("@restType", restType);

            param.Direction = ParameterDirection.Input;
            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;
            param4.Direction = ParameterDirection.Input;
            param5.Direction = ParameterDirection.Input;
            param6.Direction = ParameterDirection.Input;

            bigCommand.Parameters.Add(param);
            bigCommand.Parameters.Add(param1);
            bigCommand.Parameters.Add(param2);
            bigCommand.Parameters.Add(param3);
            bigCommand.Parameters.Add(param4);
            bigCommand.Parameters.Add(param5);
            bigCommand.Parameters.Add(param6);
            dBConnect.DoUpdateUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();


            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_EditRest";
            SqlParameter param7 = new SqlParameter("@restName", restName);
            param6.Size = 50;

            param7.Direction = ParameterDirection.Input;
            param7.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param7);
            DataSet ds = dBConnect.GetDataSetUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();

            gvRestInfo.DataSource = ds;
            gvRestInfo.DataBind();

            infoDiv.Visible = true;
            divUpdateAcctR.Visible = false;
        }

        //view all orders 
        protected void btnAllOrders_Click(object sender, EventArgs e)
        {
            string restMenuID = (string)Session["MenuID"];

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_AllOrders";

            SqlParameter param = new SqlParameter("@restMenuID", restMenuID);
            param.Direction = ParameterDirection.Input;
            bigCommand.Parameters.Add(param);
            dBConnect.DoUpdateUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            gvOrderss.DataSource = dataSet;
            gvOrderss.DataBind();

        }

        //Gets current user's name to display at the top of the page
        private void getUserName()
        {
            string restName = "";
            string emailName = (string)Session["userNameR"];
            SqlCommand comm = new SqlCommand("SELECT Name FROM [TP_Users] WHERE Name = '" + emailName + "'", dBConnect.GetConnection());
            dBConnect.GetConnection().Open();
            SqlDataReader dataRead = comm.ExecuteReader();

            while (dataRead.Read())
            {
                restName = dataRead["Name"].ToString();
                lblRestName.Text = "Welcome back, " + restName + "!";
            }
            dataRead.Close();
            dBConnect.CloseConnection();
        }

        protected void btnEditMenu_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < gvMenu.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)gvMenu.Rows[i].FindControl("chxSelect");
                if (cbox.Checked)
                {

                    txtItemType.Text = gvMenu.Rows[i].Cells[2].Text;
                    txtItemTitle.Text = gvMenu.Rows[i].Cells[3].Text;
                    txtItemDesc.Text = gvMenu.Rows[i].Cells[4].Text;
                    txtItemPrice.Text = gvMenu.Rows[i].Cells[5].Text;
                    itemid = gvMenu.Rows[i].Cells[6].Text;

                    divMenu.Visible = false;
                    divEditMenu.Visible = true;

                }
            }
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            RestMenu menuR = new RestMenu();
            string image = fileMenupic.ToString();
            string itemType = txtItemType.Text;
            string itemTitle = txtItemTitle.Text;
            string itemDesc = txtItemDesc.Text;
            string itemPrice = txtItemPrice.Text;
            string itemNo = itemid;

            //if (image == "")
           // {
                bigCommand.CommandType = CommandType.StoredProcedure;
                bigCommand.CommandText = "TP_UpdateItem";

                SqlParameter param11 = new SqlParameter("@itemType", itemType);
                SqlParameter param22 = new SqlParameter("@itemTitle", itemTitle);
                SqlParameter param33 = new SqlParameter("@itemDesc", itemDesc);
                SqlParameter param44 = new SqlParameter("@itemPrice", itemPrice);
                SqlParameter param55 = new SqlParameter("@itemNo", itemNo);

                param11.Direction = ParameterDirection.Input;
                param22.Direction = ParameterDirection.Input;
                param33.Direction = ParameterDirection.Input;
                param44.Direction = ParameterDirection.Input;
                param55.Direction = ParameterDirection.Input;

                bigCommand.Parameters.Add(param11);
                bigCommand.Parameters.Add(param22);
                bigCommand.Parameters.Add(param33);
                bigCommand.Parameters.Add(param44);
                bigCommand.Parameters.Add(param55);
                dBConnect.DoUpdateUsingCmdObj(bigCommand);
                bigCommand.Parameters.Clear();
           // }
           /* else
            {
                bigCommand.CommandType = CommandType.StoredProcedure;
                bigCommand.CommandText = "TP_UpdateItemPic";

                SqlParameter param = new SqlParameter("@image", image);
                SqlParameter param1 = new SqlParameter("@itemType", itemType);
                SqlParameter param2 = new SqlParameter("@itemTitle", itemTitle);
                SqlParameter param3 = new SqlParameter("@itemDesc", itemDesc);
                SqlParameter param4 = new SqlParameter("@itemPrice", itemPrice);
                SqlParameter param5 = new SqlParameter("@itemNo", itemNo);

                param.Direction = ParameterDirection.Input;
                param1.Direction = ParameterDirection.Input;
                param2.Direction = ParameterDirection.Input;
                param3.Direction = ParameterDirection.Input;
                param4.Direction = ParameterDirection.Input;
                param5.Direction = ParameterDirection.Input;

                bigCommand.Parameters.Add(param);
                bigCommand.Parameters.Add(param1);
                bigCommand.Parameters.Add(param2);
                bigCommand.Parameters.Add(param3);
                bigCommand.Parameters.Add(param4);
                bigCommand.Parameters.Add(param5);
                dBConnect.DoUpdateUsingCmdObj(bigCommand);
                bigCommand.Parameters.Clear();
            }*/
            
            menuR.Name = Session["userNameR"].ToString();
            

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_MenuBuilder";
            SqlParameter param6 = new SqlParameter("@restName", menuR.Name);
            param6.Size = 50;

            param6.Direction = ParameterDirection.Input;
            param6.SqlDbType = SqlDbType.VarChar;
            bigCommand.Parameters.Add(param6);
            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);

            gvMenu.DataSource = dataSet;
            gvMenu.DataBind();

            divMenu.Visible = true;
            divEditMenu.Visible = false;

        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvMenu.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)gvMenu.Rows[i].FindControl("chxSelect");
                if (cbox.Checked)
                {
                    RestMenu menyou = new RestMenu();
                    menyou.Image = gvMenu.Rows[i].Cells[1].Text;
                    menyou.FoodType = gvMenu.Rows[i].Cells[2].Text;
                    menyou.Title = gvMenu.Rows[i].Cells[3].Text;
                    menyou.Description = gvMenu.Rows[i].Cells[4].Text;
                    menyou.Price = gvMenu.Rows[i].Cells[5].Text;
                    itemid = gvMenu.Rows[i].Cells[6].Text;
                    menyou.Name = Session["userNameR"].ToString();


                    bigCommand.CommandType = CommandType.StoredProcedure;
                    bigCommand.CommandText = "TP_DeleteItem";

                    SqlParameter parm1 = new SqlParameter("@itemID", menyou.ItemID);
                    SqlParameter param2 = new SqlParameter("@menuID", menyou.MenuID);
                    SqlParameter param3 = new SqlParameter("@image", menyou.Image);
                    SqlParameter param4 = new SqlParameter("@foodType", menyou.FoodType);
                    SqlParameter param5 = new SqlParameter("@title", menyou.Title);
                    SqlParameter param6 = new SqlParameter("@desc", menyou.Description);
                    SqlParameter param7 = new SqlParameter("@price", menyou.Price);
                    SqlParameter param8 = new SqlParameter("@name", menyou.Name);


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

                    RestMenu menu = new RestMenu();
                    menu.Name = Session["userNameR"].ToString();


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
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

            addItemDiv.Visible = true;
            divMenu.Visible = false;
            
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

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            int itemID = GenerateKey(3);
            int menuID = GenerateKey(3);
            RestMenu menuu = new RestMenu();
            menuu.ItemID = itemID.ToString();
            menuu.Name = Session["userNameR"].ToString();
            menuu.MenuID = menuID.ToString();
            menuu.Image = fileImageNew.ToString();
            menuu.FoodType = txtAddItemType.Text;
            menuu.Title = txtAddItemTitle.Text;
            menuu.Description = txtAddItemDesc.Text;
            menuu.Price = txtAddItemPrice.Text;

            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_NewItem";

            SqlParameter parm1 = new SqlParameter("@itemID", menuu.ItemID);
            SqlParameter param2 = new SqlParameter("@menuID", menuu.MenuID);
            SqlParameter param3 = new SqlParameter("@image", menuu.Image);
            SqlParameter param4 = new SqlParameter("@foodType", menuu.FoodType);
            SqlParameter param5 = new SqlParameter("@title", menuu.Title);
            SqlParameter param6 = new SqlParameter("@desc", menuu.Description);
            SqlParameter param7 = new SqlParameter("@price", menuu.Price);
            SqlParameter param8 = new SqlParameter("@name", menuu.Name);


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


            RestMenu menu = new RestMenu();
            menu.Name = Session["userNameR"].ToString();


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

            divMenu.Visible = true;
            divEditMenu.Visible = false;
            addItemDiv.Visible = false;
        }
    }
}