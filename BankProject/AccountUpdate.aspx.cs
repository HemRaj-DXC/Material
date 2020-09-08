using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BankProject
{
    public partial class AccountUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
            int accountNo = Convert.ToInt32(txtAccountNo.Text);
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtFirstName.Text = dr["FirstName"].ToString();
                txtLastName.Text = dr["LastName"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtAmount.Text = dr["Amount"].ToString();
                txtCheqFacil.Text = dr["CheqFacil"].ToString();
                txtAccountType.Text = dr["AccountType"].ToString();
            }

        }

        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountUpdate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@state", txtState.Text);
            cmd.Parameters.AddWithValue("@amount", Convert.ToInt32(txtAmount.Text));
            cmd.Parameters.AddWithValue("@cheqFacil", txtCheqFacil.Text);
            cmd.Parameters.AddWithValue("@accountType", txtAccountType.Text);
            cmd.ExecuteNonQuery();
            Response.Write("*** Record Updated ***");
        }
    }
}