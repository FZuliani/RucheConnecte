using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionRuche
{
    class UserRepository
    {


        private SqlConnection connection = SingletonConnection.Connection();


        public bool CreateUser(User user)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertUser @Login, @Name, @Email, @Passwd, @Active, @Active_BK";

            SqlParameter parameterLogin = new SqlParameter()


        }


    }
}
