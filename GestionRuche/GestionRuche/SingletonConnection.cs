using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche
{
    public class SingletonConnection
    {

        private static SqlConnection connection;

        //connexion avec le serveur
        public static SqlConnection Connection()
        {
            //string ConnectionString = @"Data Source=PORTABLE-FRANCO\TECHNOBELSQL2014;Initial Catalog=BeeGestion;Integrated Security=True";


            if (connection == null)
            {
                connection = new SqlConnection("Data Source=PORTABLE-FRANCO\\TECHNOBELSQL2014; Initial Catalog=BeeGestion; Integrated Security=True");
                //connection = new SqlConnection("Data Source=10.10.10.73; Initial Catalog=BeeGestion; User ID=francois; Password=21Avril95");

            }

            return connection;
                
        }

    }
}
