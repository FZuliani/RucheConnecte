using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class TestRepository
    {

        private SqlConnection connection = SingletonConnection.Connection();


        public bool CreateTest(Test test)
        {


            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_InsertTest @Result, @User_id, @Image_id";

            //Création des parametres et ajout à la commande
            SqlParameter parameterRes = new SqlParameter("Result", test.Result);
            SqlParameter parameterUserId = new SqlParameter("User_id", test.UserId);
            SqlParameter parameterImageId = new SqlParameter("Image_id", test.ImageId);

            command.Parameters.Add(parameterRes);
            command.Parameters.Add(parameterUserId);
            command.Parameters.Add(parameterImageId);


            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                test.Id = id;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }


        }


        public Test Read(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Test WHERE Id = " + id;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            return new Test()
            {
                Id = id,
                Result = (bool)row["Result"],
                UserId = (int)row["User_Id"],
                ImageId = (int)row["Image_Id"]

            };
            
        }
        

    }
}
