using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRuche.Repository
{
    class TypeARepository
    {

        private SqlConnection connection = SingletonConnection.Connection();


        public bool InsertTypeA(TypeA typeA)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "PR_InsertTypeA @Desctiption";

            //création et ajout des parametres
            SqlParameter parameterDesc = new SqlParameter("Description", typeA.Description);

            command.Parameters.Add(parameterDesc);

            try
            {
                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();
                typeA.Id = id;
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }

        }


        public TypeA SelectTypeA(int id)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Type_Alert WHERE Id = " + id;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 1)
            {
                return null; ///TODO: faire des exceptions pour chaque Read!
            }

            DataRow row = dt.Rows[0];

            return new TypeA()
            {
                Id = id,
                Description = (string)row["Description"]

            };

        }


    }
}
