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
    public partial class ShowAllAcccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcAccountsShow", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            grdAccounts.DataSource = dt;
            grdAccounts.DataBind();
        }
    }
}