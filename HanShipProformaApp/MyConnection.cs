using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace HanShipProformaApp
{
    public class MyConnection
    {
        public static SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=HanShipDB;Integrated Security=True;TrustServerCertificate=True");
        public static void checkmyconnetion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
            else
            {

            }
        }


    }
}
