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
    public partial class WithdrawAmount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountWithdraw", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountNo", Convert.ToInt32(txtAccountNo.Text));
            cmd.Parameters.AddWithValue("@tranAmount", txtWithdraw.Text);
            cmd.Parameters.Add(new SqlParameter("@res", SqlDbType.VarChar, 30));
            cmd.Parameters["@res"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string res = cmd.Parameters["@res"].Value.ToString();
            Response.Write(res);
        }
    }
}