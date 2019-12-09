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
    }
}