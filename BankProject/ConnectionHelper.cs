using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BankProject
{
    public class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("integrated security=true;initial catalog=bank;data source=DESKTOP-EVNJH9Q\\SQLEXPRESS");
        }
    }
}