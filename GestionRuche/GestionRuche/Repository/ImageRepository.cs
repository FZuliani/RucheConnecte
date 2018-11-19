using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class ImageRepository
    {
        private SqlConnection connection = SingletonConnection.Connection();

        //INSERT 
        public bool CreateImage(Image image)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_InsertImage @Result,@TimeStamp,@ImagePos,@User_id,@Hive_id";

            //Creation des paramètres de le commande

            SqlParameter parameterResult = new SqlParameter("Result", image.Result);
            SqlParameter parameterTimeStamp = new SqlParameter("TimeStamp", image.Date);
            SqlParameter parameterImagePos = new SqlParameter("ImagePos", image.ImagePos);
            SqlParameter parameterUserId = new SqlParameter("User_id", image.UserId);
            SqlParameter parameterHiveId = new SqlParameter("Hive_id", image.HiveId);

            command.Parameters.Add(parameterResult);
            command.Parameters.Add(parameterTimeStamp);
            command.Parameters.Add(parameterImagePos);
            command.Parameters.Add(parameterUserId);
            command.Parameters.Add(parameterHiveId);

            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                image.Id = id;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Image ReadImage(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Image Where Id =" + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count !=1)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            return new Image()
            {
                Id=id,
                Result = (bool)row["Result"],
                Date = (DateTime)row["TimeStamp"],
                ImagePos = (string)row["ImagePos"],
                UserId =(User)row["User_id"],
                HiveId = (Hive)row["Hive_id"],
            };
        }

        public List<Image> ReadAllImage()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Image";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Image> image = new List<Image>();
            foreach (DataRow row in dt.Rows)
            {
                image.Add(new Image()
                {
                    Id=(int)row["Id"],
                    Result =(bool)row["Result"],
                    Date = (DateTime)row["TimeStamp"],
                    ImagePos = (string)row["ImagePos"],
                    UserId = (User)row["User_id"],
                    HiveId = (Hive)row["Hive_id"],
                });
            }
            return image;
        }
        //UPDATE
        public bool UpdateImage(int id , string column ,string ValueChange )
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateImage @Id,@Column,@var_modif";

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
        //DELETE
        public bool DeleteImage(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_DelImage" + id;
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
