using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankProject
{
    public partial class AccountSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int accountNo = Convert.ToInt32(txtAccountNo.Text);
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtFirstname.Text = dr["FirstName"].ToString();
                txtLastname.Text = dr["LastName"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtState.Text = dr["State"].ToString();
                txtAmount.Text = dr["Amount"].ToString();
                txtCheqFacil.Text = dr["CheqFacil"].ToString();
                txtAccountType.Text = dr["AccountType"].ToString();
            }
            else
            {
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtAmount.Text = "";
                txtCheqFacil.Text = "";
                txtAccountType.Text = ""; 

            }
        }
    }
}