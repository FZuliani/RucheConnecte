using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    public class AlertRepository
    {
        private SqlConnection connection = SingletonConnection.Connection();

        //Insert

        public bool InsertAlert(Alert alert)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "EXEC PR_InsertAlert @Date, @AlertA, @TypeAId, @HiveId ";

            //création des parametres de la commande   

            SqlParameter parameterDate = new SqlParameter("Date", alert.Date);
            SqlParameter parameterAlertA = new SqlParameter("AlertA", alert.AlertA);
            SqlParameter parameterTypeAId = new SqlParameter("TypeAId", alert.TypeAId);
            SqlParameter parameterHiveId = new SqlParameter("HiveId", alert.HiveId);

            //ajout des parametres à la commande

            command.Parameters.Add(parameterDate);
            command.Parameters.Add(parameterAlertA);
            command.Parameters.Add(parameterTypeAId);
            command.Parameters.Add(parameterHiveId);

            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                alert.Id = id;
                return true;
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
                return false;
            }           
        }

        public List<Alert> ReadAlert ()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Alert";

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Alert> alert = new List<Alert>();

            foreach (DataRow row in dt.Rows)
            {
                alert.Add(new Alert()
                {
                    Id = (int)row["Id"],
                    Date = (DateTime)row["Date"],
                    AlertA = (bool)row["AlertA"],
                    TypeAId = (TypeA)row["TypeAId"],
                    HiveId =(int)row["HiveId"]

                });
            }
            return alert;
        }
    }
}
