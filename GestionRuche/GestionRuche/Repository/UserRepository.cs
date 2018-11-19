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
            //Insert

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertUser @Login, @Name, @Email, @Passwd, @Active, @Active_BK";

            //création des parametres de la commande

            SqlParameter parameterLogin = new SqlParameter("Login", user.Login);
            SqlParameter parameterName = new SqlParameter("Name", user.Name);
            SqlParameter parameterEmail = new SqlParameter("Email", user.Email);
            SqlParameter parameterPasswd = new SqlParameter("Passwd", user.Passwd);
            SqlParameter parameterActive = new SqlParameter("Active", user.Active);
            SqlParameter parameterActive_BK = new SqlParameter("Active_BK", user.ActiveBeeK);


            //ajout des parametres à la commande

            command.Parameters.Add(parameterLogin);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterEmail);
            command.Parameters.Add(parameterPasswd);
            command.Parameters.Add(parameterActive);
            command.Parameters.Add(parameterActive_BK);

            return command.ExecuteNonQuery() == 1;
        }

        //Update




    }
}
