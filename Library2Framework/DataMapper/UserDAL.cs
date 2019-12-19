namespace Library2Framework.DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DomainModel;
    using Library2Framework.Utils;

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

        public static void AddLibrarian(User librarian, bool isReader)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddLibrarian", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter firstName = new SqlParameter("@FirstName", librarian.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", librarian.LastName);
                SqlParameter address = new SqlParameter("@Address", librarian.Address);
                SqlParameter phone = new SqlParameter("@Phone", librarian.PhoneNumber);
                SqlParameter email = new SqlParameter("@Email", librarian.Email);
                SqlParameter isReaderSql = new SqlParameter("@IsReader", isReader==true ? 1 : 0);

                cmd.Parameters.Add(firstName);
                cmd.Parameters.Add(lastName);
                cmd.Parameters.Add(address);
                cmd.Parameters.Add(phone);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(isReaderSql);


                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }
        }

        public static void AddReader(User reader)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddReader", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter firstName = new SqlParameter("@FirstName", reader.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", reader.LastName);
                SqlParameter address = new SqlParameter("@Address", reader.Address);
                SqlParameter phone = new SqlParameter("@Phone", reader.PhoneNumber);
                SqlParameter email = new SqlParameter("@Email", reader.Email);

                cmd.Parameters.Add(firstName);
                cmd.Parameters.Add(lastName);
                cmd.Parameters.Add(address);
                cmd.Parameters.Add(phone);
                cmd.Parameters.Add(email);

                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }
        }

        public static Boolean CheckUser(User user)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter emailSql = new SqlParameter("@Email", user.Email);
                              
                cmd.Parameters.Add(emailSql);
                
                con.Open();
                int counter = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }
                reader.Close();
                return counter == 0 ? false : true;
            }
        }
    }
}