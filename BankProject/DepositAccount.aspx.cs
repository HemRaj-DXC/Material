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
    public partial class DepositAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountDeposit", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            cmd.Parameters.AddWithValue("@tranAmount", Convert.ToInt32(txtDepositAmount.Text));
            cmd.ExecuteNonQuery();
            Response.Write("*** Record Inserted ***");
        }
    }
}