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
    public class EditionDAL
    {
        public static List<Edition> GetBooksAlphabetical()
        {
            using (SqlConnection con = GetDBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetBooksAlphabetical", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //deschidem conexiunea la BD        
                con.Open();

                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Edition> result = new List<Edition>();

                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Edition()
                        {
                            Name = reader.GetString(0),
                            PublishingHouseName = reader.GetString(1),
                            PageNr = reader.GetInt32(2),
                            PublicationYear = reader.GetInt32(3),
                            Domain = reader.GetString(4),
                            InitialStock = reader.GetInt32(5),
                            BorrowedBooks = reader.GetInt32(6),
                            ReadingRoomBooks = reader.GetInt32(7)
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }

        public static List<Edition> GetBorrowedBooksAlphabetical()
        {
            using (SqlConnection con = GetDBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetBorrowedBooksAlphabetical", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //deschidem conexiunea la BD        
                con.Open();

                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Edition> result = new List<Edition>();

                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Edition()
                        {
                            Name = reader.GetString(0),
                            PublishingHouseName = reader.GetString(1),
                            PageNr = reader.GetInt32(2),
                            PublicationYear = reader.GetInt32(3),
                            Domain = reader.GetString(4),
                            InitialStock = reader.GetInt32(5),
                            BorrowedBooks = reader.GetInt32(6),
                            ReadingRoomBooks = reader.GetInt32(7)
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }
    }
}
