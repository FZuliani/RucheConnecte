using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GestionRuche.DAL.Models;
using System.Threading.Tasks;

namespace GestionRuche.DAL.Repository
{
    public class StatueRepository
    {

        private SqlConnection connection = SingletonConnection.Connection();



        public bool InsertStatue(Statue statue)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertStatue @Agressivity, @Queen, @Age_Queen, @NB_Cadres, @Morte, @HiveID";

            //création et ajout des parametres

            SqlParameter parameterAgressivity = new SqlParameter("Agresssivity", statue.Agressivity);
            SqlParameter parameterQueen = new SqlParameter("Queen", statue.Queen);
            SqlParameter parameterAgeQueen = new SqlParameter("Age_Queen", statue.Age_Queen);
            SqlParameter parameterNB_Cadres = new SqlParameter("NB_Cadres", statue.NB_Cadres);
            SqlParameter parameterMorte = new SqlParameter("Morte", statue.Morte);
            SqlParameter parameterHiveId = new SqlParameter("HiveID", statue.Hive_id);

            command.Parameters.Add(parameterAgressivity);
            command.Parameters.Add(parameterQueen);
            command.Parameters.Add(parameterAgeQueen);
            command.Parameters.Add(parameterNB_Cadres);
            command.Parameters.Add(parameterMorte);
            command.Parameters.Add(parameterHiveId);


            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                statue.id = id;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Statue SelectStatue(int id)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Statue WHERE id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            if ((bool)row["Queen"])
            {
                return new Statue
                {
                    id = id,
                    Date = (DateTime)row["Date"],
                    Agressivity = (bool)row["Agressivity"],
                    Queen = (bool)row["Queen"],
                    Age_Queen = (int)row["Age_Queen"],
                    NB_Cadres = (int)row["NB_Cadres"],
                    Morte = (bool)row["Mort"],
                    Hive_id = (int)row["Hive_id"]
                };

            }
            return new Statue
            {
                id = id,
                Date = (DateTime)row["Date"],
                Agressivity = (bool)row["Agressivity"],
                Queen = (bool)row["Queen"],
                NB_Cadres = (int)row["NB_Cadres"],
                Morte = (bool)row["Mort"],
                Hive_id = (int)row["Hive_id"]
            };


        }

        public bool UpdateStatue(int id, string column, string ValueChange)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateStatu @id, @column, @ValueChange";

            //création et ajout des parametres
            SqlParameter parameterId = new SqlParameter("id", id);
            SqlParameter parameterColumn = new SqlParameter("column", column);
            SqlParameter parameterValueChange = new SqlParameter("id", ValueChange);

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


    }
}
