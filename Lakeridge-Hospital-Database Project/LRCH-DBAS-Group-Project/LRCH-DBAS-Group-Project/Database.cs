using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Markup;

namespace LRCH_DBAS_Group_Project
{
    public class Database
    {
        #region PROPERTIES

        private static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=final_project;Integrated Security=True";

        public static SqlConnection conn = new SqlConnection(connString);

        #endregion

    }
}
