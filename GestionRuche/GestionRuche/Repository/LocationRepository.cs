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
    public class LocationRepository
    {

        private SqlConnection connection = SingletonConnection.Connection();


        public bool InsertLocation(Location location)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertLocation @TimeStamp, @Latitude, @Longitude, @Hive_id, @Zone_id, @Flower_id";

            //création et ajout des parametres
            SqlParameter parameterTimeStamp = new SqlParameter("TimeStamp", location.TimeStamp);
            SqlParameter parameterLat = new SqlParameter("Latitude", location.Latitude);
            SqlParameter parameterLong = new SqlParameter("Longitude", location.longitude);
            SqlParameter parameterHiveID = new SqlParameter("Hive_id", location.Hive_id);
            SqlParameter parameterZoneID = new SqlParameter("Zone_id", location.Zone_id);
            SqlParameter parameterFlowerID = new SqlParameter("Zone_id", location.Flower_id);

            command.Parameters.Add(parameterTimeStamp);
            command.Parameters.Add(parameterLat);
            command.Parameters.Add(parameterLong);
            command.Parameters.Add(parameterHiveID);
            command.Parameters.Add(parameterZoneID);

            try
            {
                connection.Open();
                int id = command.ExecuteNonQuery();
                connection.Close();
                location.id = id;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

            return true;

        }


        public Location SelectLocation(int id)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Location WHERE id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            return new Location()
            {
                id = id,
                TimeStamp = (DateTime)row["TimeStamp"],
                Latitude = (int)row["Latitude"],
                longitude = (int)row["Longitude"],
                Orientation = (string)row["Orientation"],
                Nectar_Type = (string)row["Nectar_Type"],

            };

        }

        public bool UpdateLocation(int id, string column, string ValueChange)
        {

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC UpdateLocation @id, @column, @ValueChange";

            //création et ajout des parametres
            SqlParameter parameterID = new SqlParameter("id", id);
            SqlParameter parameterColumn = new SqlParameter("column", column);
            SqlParameter parameterValueC = new SqlParameter("ValueChange", ValueChange);

            command.Parameters.Add(parameterID);
            command.Parameters.Add(parameterColumn);
            command.Parameters.Add(parameterValueC);

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


        public bool DeleteLocation(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_DelLocation " + id;

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
