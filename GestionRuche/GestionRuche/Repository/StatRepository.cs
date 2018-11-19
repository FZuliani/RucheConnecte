using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class StatRepository
    {


        private SqlConnection connection = SingletonConnection.Connection();

        public bool Create(Statistic stat)
        {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_InsertStat @TimeStamp, @Temperature, @Humidity, @Air_Quality, @Hive_id";

            //création et ajout des parametres à la commande

            SqlParameter parameterTime = new SqlParameter("TimeStamp", stat.Date);
            SqlParameter parameterTemp = new SqlParameter("Temperature", stat.Temperature);
            SqlParameter parameterHumidity = new SqlParameter("Humidity", stat.Humidity);
            SqlParameter parameterAir_Q = new SqlParameter("Air_Quality", stat.AirQuality);
            SqlParameter parameterHive = new SqlParameter("Hive_id", stat.HiveId);

            command.Parameters.Add(parameterTime);
            command.Parameters.Add(parameterTemp);
            command.Parameters.Add(parameterHumidity);
            command.Parameters.Add(parameterAir_Q);
            command.Parameters.Add(parameterHive);


            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                stat.Id = id;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }


        }




        public Statistic Read(int id)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Statistic WHERE Id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            return new Statistic()
            {
                Id = id,
                Date = (DateTime)row["TimeStamp"],
                Temperature = (int)row["Temperature"],
                Humidity = (int)row["Humidity"],
                AirQuality = (int)row["Air_Quality"],
                HiveId = (int)row["Hive_id"]
            };
            
        }


        public bool UpdateStat(int id, string column, string ValueModif)
        {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateStat "+ id + " ,"+column +" ,"+ ValueModif;

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


        public bool DeleteStat(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_DelStat " + id;

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
