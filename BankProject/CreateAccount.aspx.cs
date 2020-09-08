using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankProject
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountGenerate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string accno = dr["Accno"].ToString();
            txtAccountNo.Text = accno;           
            if(!IsPostBack)
            {
                ddlCheqFacility.Items.Add("Yes");
                ddlCheqFacility.Items.Add("No");

                ddlAccountType.Items.Add("Savings");
                ddlAccountType.Items.Add("Current");
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountCreate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@state", txtState.Text);
            cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@cheqFacil", ddlCheqFacility.Text);
            cmd.Parameters.AddWithValue("@accountType", ddlAccountType.Text);
            cmd.ExecuteNonQuery();
            Response.Write("*** Record Inserted ***");
        }
    }
}