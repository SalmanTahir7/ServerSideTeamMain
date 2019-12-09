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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnAcctInfo_Click(object sender, EventArgs e)
        {

            

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

        protected void btnAllOrders_Click(object sender, EventArgs e)
        {

        }
    }
}