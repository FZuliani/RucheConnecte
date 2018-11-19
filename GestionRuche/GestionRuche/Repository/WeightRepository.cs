using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class WeightRepository
    {

        private SqlConnection connection = SingletonConnection.Connection();


        public bool InsertWeight(Weight weight)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_InsertWeight @TimeStamp, @Weight, @Hive_id";

            //Création et ajout des parametres

            SqlParameter parameterDate = new SqlParameter("TimeStamp", weight.Date);
            SqlParameter parameterWeight = new SqlParameter("Weight", weight.weight);
            SqlParameter parameterHiveId = new SqlParameter("Hive_id", weight.HiveId);

            command.Parameters.Add(parameterDate);
            command.Parameters.Add(parameterWeight);
            command.Parameters.Add(parameterHiveId);

            try
            {

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                weight.Id = id;
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

        }



        public Weight SelectWeight(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Weight WHERE Id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 1)
            {

                return null;

            }

            DataRow row = dt.Rows[0];

            return new Weight()
            {
                Id = id,
                Date = (DateTime)row["TimeStamp"],
                weight = (int)row["Weight"],
                HiveId = (int)row["Hive_id"]
            };

        }


        public bool UpdateWeight(int id, string column, string ValueChange)
        {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateWeight " + id + " ," + column + " ," + ValueChange;

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

        public bool DeleteWeight(Weight weight)
        {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_DelWeight " + weight.Id;

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
