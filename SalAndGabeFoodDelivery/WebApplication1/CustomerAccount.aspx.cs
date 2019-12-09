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
    public partial class CustomerAccount : System.Web.UI.Page

    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand bigCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = new User();
                string custName = (string)Session["userNameC"];
                user.Name = custName;



                bigCommand.CommandType = CommandType.StoredProcedure;
                bigCommand.CommandText = "TP_EditCust";
                SqlParameter param = new SqlParameter("@custName", user.Name);
                param.Size = 50;

                param.Direction = ParameterDirection.Input;
                param.SqlDbType = SqlDbType.VarChar;
                bigCommand.Parameters.Add(param);
                DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);
                bigCommand.Parameters.Clear();

                gvCustInfo.DataSource = dataSet;
                gvCustInfo.DataBind();
            }
        }

        protected void btnEditInfo_Click(object sender, EventArgs e)
        {

                    txtCustName.Text = gvCustInfo.Rows[0].Cells[0].Text;
                    txtEmail.Text = gvCustInfo.Rows[0].Cells[1].Text;
                    txtPassword.Text = gvCustInfo.Rows[0].Cells[2].Text;
                    txtDelAddy.Text = gvCustInfo.Rows[0].Cells[3].Text;
                    txtBillAddy.Text = gvCustInfo.Rows[0].Cells[4].Text;


                    divAcctSet.Visible = true;
                    infoDiv.Visible = false;
                

        }

        //Rebind gv to show Updates!!!
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string custName = txtCustName.Text;
            string custEmail = txtEmail.Text;
            string custPassword = txtPassword.Text;
            string custDelAddy = txtDelAddy.Text;
            string custBillAddy = txtBillAddy.Text;
            int loginID = Convert.ToInt32(Session["LoginID"].ToString());


            bigCommand.CommandType = CommandType.StoredProcedure;
            bigCommand.CommandText = "TP_UpdateCustomer";

            SqlParameter param = new SqlParameter("@loginID", loginID);
            SqlParameter param1 = new SqlParameter("@custName", custName);
            SqlParameter param2 = new SqlParameter("@custPW", custPassword);
            SqlParameter param3 = new SqlParameter("@custDelAdd", custDelAddy);
            SqlParameter param4 = new SqlParameter("@custBillAdd", custBillAddy);
            SqlParameter param5 = new SqlParameter("@custEmail", custEmail);

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


            DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(bigCommand);
            bigCommand.Parameters.Clear();


        }
    }
}