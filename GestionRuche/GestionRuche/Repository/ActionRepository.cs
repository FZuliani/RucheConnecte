using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionRuche.DAL.Models;

namespace GestionRuche.DAL.Repository
{
    public class ActionRepository
    {

        private SqlConnection connection = SingletonConnection.Connection();


        public bool InsertAction(Actions action)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertAction @DateAction, @Description, @Hive_id";


            //création et ajout des parametres
            SqlParameter parameterDateA = new SqlParameter("DateAction", action.DateAction);
            SqlParameter parameterDesc = new SqlParameter("Description", action.Description);
            SqlParameter parameterHiveID = new SqlParameter("Hive_id", action.Hive_id);


            command.Parameters.Add(parameterDateA);
            command.Parameters.Add(parameterDesc);
            command.Parameters.Add(parameterHiveID);

            try
            {

                connection.Open();
                int id = command.ExecuteNonQuery();
                connection.Close();
                action.id = id;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
                return true;
        }


        public Actions SelectAction(int id)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM [Action] WHERE id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            return new Actions
            {
                id = id,
                DateAction = (DateTime)row["DateAction"],
                Description = (string)row["Description"],
                Hive_id = (int)row["Hive_id"]
            };
            
        }


        public bool UpdateAction(int id, string Action)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateAction @id, @column, @ValueChange";

            //création et ajout des parametres
            SqlParameter parameterId = new SqlParameter("id", id);
            SqlParameter parameterColumn = new SqlParameter("column" ,Action[0]);
            SqlParameter parameterValueChange = new SqlParameter("ValueChange", Action[1]);

            command.Parameters.Add(parameterId);
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
                throw;
            }

            return rows == 1;

        }


        public bool DeleteAction(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_DelAction " + id;

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
