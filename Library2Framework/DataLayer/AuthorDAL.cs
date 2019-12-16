using Library2Framework.DomainLayer;
using Library2Framework.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DataLayer
{
    public class AuthorDAL
    {
        public static List<Author> GetAuthorsForBook(String BookName, int PublicationYear, String PublishingHouseName)
        {
            using (SqlConnection con = GetDBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetAuthorsForBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter BookNameSql = new SqlParameter("@BookName", BookName);
                SqlParameter PublicationYearSql = new SqlParameter("@PublicationYear", PublicationYear);
                SqlParameter PublishingHouseNameSql = new SqlParameter("@PublishingHouseName", PublishingHouseName);

                cmd.Parameters.Add(BookNameSql);
                cmd.Parameters.Add(PublicationYearSql);
                cmd.Parameters.Add(PublishingHouseNameSql);
                //deschidem conexiunea la BD        
                con.Open();

                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Author> result = new List<Author>();

                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Author()
                        {
                            ID = reader.GetInt32(0),
                            AuthorName = reader.GetString(1)
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }

    }
}
