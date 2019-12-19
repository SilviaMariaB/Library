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
            using (SqlConnection con = DBConnection.Connection)
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
                            BookType=reader.GetString(5),
                            InitialStock = reader.GetInt32(6),
                            BorrowedBooks = reader.GetInt32(7),
                            ReadingRoomBooks = reader.GetInt32(8)
                        }
                 );
                }
                reader.Close();
                return result;
            }
        }

        public static List<Edition> GetBorrowedBooksAlphabetical()
        {
            using (SqlConnection con = DBConnection.Connection)
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

        public static Boolean CheckBook(string bookName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter bookNameSQL = new SqlParameter("@BookName", bookName);

                cmd.Parameters.Add(bookNameSQL
);

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

        public static Boolean CheckEdition(string bookName, string publishingHouse, int publicationYear)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForEdition", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter bookNameSQL = new SqlParameter("@BookName", bookName);
                SqlParameter publishingHouseSQL = new SqlParameter("@PublishingHouse", publishingHouse);
                SqlParameter publicationYearSQL = new SqlParameter("@PublicationYear", publicationYear);

                cmd.Parameters.Add(bookNameSQL);
                cmd.Parameters.Add(publishingHouseSQL);
                cmd.Parameters.Add(publicationYearSQL);

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
        
        public static void AddEdition(Edition edition,Author author)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddEdition", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter bookName = new SqlParameter("@Name", edition.Name);
                SqlParameter domainName = new SqlParameter("@Domain", edition.Domain);
                SqlParameter authorName = new SqlParameter("@Author", author.AuthorName);
                SqlParameter publishingHouse = new SqlParameter("@PublishingHouse", edition.PublishingHouseName);
                SqlParameter pageNr = new SqlParameter("@PageNr", edition.PageNr);
                SqlParameter bookType = new SqlParameter("@BookType", edition.BookType);
                SqlParameter publicationYear = new SqlParameter("@PublicationYear", edition.PublicationYear);
                SqlParameter initialStock = new SqlParameter("@InitialStock", edition.InitialStock);

                cmd.Parameters.Add(bookName);
                cmd.Parameters.Add(domainName);
                cmd.Parameters.Add(authorName);
                cmd.Parameters.Add(publishingHouse);
                cmd.Parameters.Add(pageNr);
                cmd.Parameters.Add(bookType);
                cmd.Parameters.Add(publicationYear);
                cmd.Parameters.Add(initialStock);

                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }
        }

        public static void AddAuthorForEdition(Author author, Edition edition)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddAuthorForBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter bookName = new SqlParameter("@BookName", edition.Name);
                SqlParameter publicationYear = new SqlParameter("@PublicationYear", edition.PublicationYear);
                SqlParameter publishingHouse = new SqlParameter("@PublishingHouseName", edition.PublishingHouseName);
                SqlParameter authorName = new SqlParameter("@AuthorName", author.AuthorName);
                

                cmd.Parameters.Add(bookName);
                cmd.Parameters.Add(publicationYear);
                cmd.Parameters.Add(publishingHouse);
                cmd.Parameters.Add(authorName);
                

                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }

        }

        public static void BorrowBook(User user,Edition edition, Author author, DateTime endDate)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddBorrowedBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter firstNameSQL = new SqlParameter("@FirstName", user.FirstName);
                SqlParameter lastNameSQL = new SqlParameter("@LastName", user.LastName);
                SqlParameter bookNameSQL = new SqlParameter("@BookName", edition.Name);
                SqlParameter authorSQL = new SqlParameter("@Author", author.AuthorName);
                SqlParameter publishingHouseSQL = new SqlParameter("@PublishingHouse", edition.PublishingHouseName);
                SqlParameter publicationYearSQL = new SqlParameter("@PublicationYear", edition.PublicationYear);
                SqlParameter endDateSQL = new SqlParameter("@EndDate", endDate);

                cmd.Parameters.Add(firstNameSQL);
                cmd.Parameters.Add(lastNameSQL);
                cmd.Parameters.Add(bookNameSQL);
                cmd.Parameters.Add(authorSQL);
                cmd.Parameters.Add(publishingHouseSQL);
                cmd.Parameters.Add(publicationYearSQL);
                cmd.Parameters.Add(endDateSQL);

                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }

        }
    }
}
