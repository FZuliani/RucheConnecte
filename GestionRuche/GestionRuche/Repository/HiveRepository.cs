using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class HiveRepository
    {
        private SqlConnection connection = SingletonConnection.Connection();

        //Insert
        public bool InsertHive(Hive hive)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "Exec PR_InsertHive @Name,@Description,@Initial_Weight,@Active,@User_id";

            //Creation des paramètre de la commande 

            SqlParameter parameterName = new SqlParameter("Name", hive.Name);
            SqlParameter parameterDescription = new SqlParameter("Description", hive.Description);
            SqlParameter parameterInitialWeight = new SqlParameter("Initial_Weight", hive.InitWeight);
            SqlParameter parameterActive = new SqlParameter("Active", hive.Active);
            SqlParameter parameterUserID = new SqlParameter("User_id", hive.UserId);

            //Ajout des paramètre ala commande

            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterDescription);
            command.Parameters.Add(parameterInitialWeight);
            command.Parameters.Add(parameterActive);
            command.Parameters.Add(parameterUserID);

            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                hive.Id = id;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Hive SelectHive(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Hive WHERE Id =" + id;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 1)
            {
                return null;
            }
            DataRow row = dt.Rows[0];

            //Je map les données de la db dans un objet

            return new Hive()
            {
                Id = id,
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                InitWeight = (int)row["Initial_Weight"],
                Active = (bool)row["Active"],
                UserId = (int)row["User_id"],
            };
        }

        public List<Hive> ReadAllHive()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Hive";

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Hive> hive = new List<Hive>();

            foreach (DataRow row in dt.Rows)
            {
                hive.Add(new Hive()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"],
                    InitWeight = (int)row["Initial_Weight"],
                    Active = (bool)row["Active"],
                    UserId = (int)row["User_id"],
                });
            }
            return hive;
        }
        //Update
        public bool UpdateHive(int id, string column, string ValueChange)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateHive @Id,@Column,@var_modif";

            SqlParameter parameterId = new SqlParameter("Id", id);
            SqlParameter parameterColumn = new SqlParameter("Column", column);
            SqlParameter parameterValue = new SqlParameter("var_modif", ValueChange);

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterColumn);
            command.Parameters.Add(parameterValue);

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
        //Delete
        public bool DeleteHive (int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_DelHive " + id;

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
                return false;
            }
            return rows == 1;
        }
    }
}
