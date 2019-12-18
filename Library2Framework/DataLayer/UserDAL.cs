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
    public class UserDAL
    {

        public static List<User> GetLibrarians()
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetLibrarians", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<User> result = new List<User>();
                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new User()
                        {
                            ID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Address = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Email = reader.GetString(5),
                            Reader = reader.GetInt32(6) == 0 ? false : true,
                            Librarian = reader.GetInt32(7) == 0 ? false : true
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }

        public static List<User> GetReaders()
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetReaders", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<User> result = new List<User>();
                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new User()
                        {
                            ID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Address = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Email = reader.GetString(5),
                            Reader = reader.GetInt32(6) == 0 ? false : true,
                            Librarian = reader.GetInt32(7) == 0 ? false : true
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }
    }
}