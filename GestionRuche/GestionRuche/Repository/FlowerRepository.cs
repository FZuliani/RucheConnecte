using GestionRuche.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class FlowerRepository
    {
        private SqlConnection connection = SingletonConnection.Connection();

        //INSERT
        public bool CreateFlower(Flower flower)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_InsertFlower @FlowerT ";

            SqlParameter parameterFlowerT = new SqlParameter("FlowerT",flower.FlowerType);


            command.Parameters.Add(parameterFlowerT);

            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                flower.Id = id;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Flower ReadFlower(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM FlowerType WHERE Id =" + id;

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count !=1)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            return new Flower()
            {
                Id = id,
                FlowerType = (string)row["Flower_Type"]
            };
        }
        //UPDATE
        public bool UpdateFlower(int id, string column, string ValueChange)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_UpdateFlower @Id,@Column,@var_modif";

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
        public bool DeleteFlower(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC PR_DelFlower "+ id;

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
