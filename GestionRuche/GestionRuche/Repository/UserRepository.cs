using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GestionRuche
{
    class UserRepository
    {


        private SqlConnection connection = SingletonConnection.Connection();


        public bool CreateUser(User user)
        {

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

            try
            {

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                user.Id = id;
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }



        }


        //récupère un Utilisateur en fonction de son ID
        public User ReadUser(int id)
        {

            SqlCommand command = connection.CreateCommand();

            try
            {


                command.CommandText = ("SELECT * FROM User WHERE Id = " + id);
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataSet ds = new DataSet();

                DataTable dt = ds.Tables[0];

                da.Fill(ds);

                if (dt.Rows.Count != 1)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];

                return new User()
                {
                    Id = id,
                    Login = (string)row["Login"],
                    Passwd = (string)row["Password"],
                    Name = (string)row["Name"],
                    Tel = (int)row["Num_Tel"],
                    Email = (string)row["Email"],
                    Active = (bool)row["Active"],
                    ActiveBeeK = (bool)row["Active_BeeKeeper"]

                };
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }


        public bool UpdateUser(int id, string Column, string ValueChange)
        {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateUser @Id, @Column, @var_modif";

            SqlParameter parameterID = new SqlParameter("Id", id);
            SqlParameter parameterColumn = new SqlParameter("Column", Column);
            SqlParameter parameterValueChange = new SqlParameter("var_modif", ValueChange);

            command.Parameters.Add(parameterID);
            command.Parameters.Add(parameterColumn);
            command.Parameters.Add(parameterValueChange);


            int rows = 0;
            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return rows == 1;

        }


        public bool DeleteUser(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_DelUser " + id;
            int rows = 0;
            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            return rows == 1;
        }

    }
}
