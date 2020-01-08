// <copyright file="EditionDAL.cs" company="Transilvania University of Brasov">
// Copyright (c) Brassoi Silvia Maria. All rights reserved.
// </copyright>

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

    public class EditionDAL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EditionDAL));

        public static List<Edition> GetEditionsAlphabetical()
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetBooksAlphabetical", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                con.Open();

                List<Edition> result = new List<Edition>();

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
                            BookType = reader.GetString(4),
                            InitialStock = reader.GetInt32(5),
                            CurrentStock = reader.GetInt32(6),
                            BorrowedBooks = reader.GetInt32(7),
                            ReadingRoomBooks = reader.GetInt32(8),
                        });
                }

                reader.Close();
            log.Info("GetBooksAlphabetical procedure has been called from EditionDAL." );

                return result;
            }
        }

        public static List<Edition> GetBorrowedEditionsAlphabetical()
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetBorrowedBooksAlphabetical", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                con.Open();

                List<Edition> result = new List<Edition>();

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
                            InitialStock = reader.GetInt32(4),
                            CurrentStock = reader.GetInt32(5),
                            BorrowedBooks = reader.GetInt32(6),
                            ReadingRoomBooks = reader.GetInt32(7),
                        });
                }

                reader.Close();
            log.Info("GetBorrowedBooksAlphabetical procedure has been called from EditionDAL." );

                return result;
            }
        }

        public static bool CheckEdition(string bookName, string publishingHouse, int publicationYear)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForEdition", con)
                {
                    CommandType = CommandType.StoredProcedure,
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
            log.Info("GetIdForEdition procedure has been called from EditionDAL." );

                return counter == 0 ? false : true;
            }
        }

        public static void AddEdition(Edition edition, Author author, string domain)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddEdition", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookName = new SqlParameter("@Name", edition.Name);
                SqlParameter domainName = new SqlParameter("@Domain", domain);
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

                con.Open();
                cmd.ExecuteNonQuery();
            }
            log.Info("AddEdition procedure has been called from EditionDAL." );

        }

        public static void AddAuthorForEdition(Author author, Edition edition)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                // creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                // si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddAuthorForBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookName = new SqlParameter("@BookName", edition.Name);
                SqlParameter publicationYear = new SqlParameter("@PublicationYear", edition.PublicationYear);
                SqlParameter publishingHouse = new SqlParameter("@PublishingHouseName", edition.PublishingHouseName);
                SqlParameter authorName = new SqlParameter("@AuthorName", author.AuthorName);

                cmd.Parameters.Add(bookName);
                cmd.Parameters.Add(publicationYear);
                cmd.Parameters.Add(publishingHouse);
                cmd.Parameters.Add(authorName);

                con.Open();

                cmd.ExecuteNonQuery();
            }
            log.Info("AddAuthorForBook procedure has been called from EditionDAL." );

        }

        public static void BorrowEdition(string email, Edition edition, Author author, DateTime endDate)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddBorrowedBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter emailSql = new SqlParameter("@Email", email);
                SqlParameter bookNameSQL = new SqlParameter("@BookName", edition.Name);
                SqlParameter authorSQL = new SqlParameter("@Author", author.AuthorName);
                SqlParameter publishingHouseSQL = new SqlParameter("@PublishingHouse", edition.PublishingHouseName);
                SqlParameter publicationYearSQL = new SqlParameter("@PublicationYear", edition.PublicationYear);
                SqlParameter endDateSQL = new SqlParameter("@EndDate", endDate);

                cmd.Parameters.Add(emailSql);
                cmd.Parameters.Add(bookNameSQL);
                cmd.Parameters.Add(authorSQL);
                cmd.Parameters.Add(publishingHouseSQL);
                cmd.Parameters.Add(publicationYearSQL);
                cmd.Parameters.Add(endDateSQL);

                con.Open();

                cmd.ExecuteNonQuery();
            }
            log.Info("AddBorrowedBook procedure has been called from EditionDAL." );

        }

        public static Inventory GetEditionInventory(string bookName, string publishingHouse, int publicationYear)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetEditionInventory", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookNameSQL = new SqlParameter("@BookName", bookName);
                SqlParameter publishingHouseSQL = new SqlParameter("@PublishHouseName", publishingHouse);
                SqlParameter publicationYearSQL = new SqlParameter("@PubYear", publicationYear);

                cmd.Parameters.Add(bookNameSQL);
                cmd.Parameters.Add(publishingHouseSQL);
                cmd.Parameters.Add(publicationYearSQL);

                con.Open();

                // new inventory();
                Inventory inventory = default(Inventory);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    inventory.CurrentStock = reader.GetInt32(0);
                    inventory.InitialStock = reader.GetInt32(1);
                }

                reader.Close();
            log.Info("GetEditionInventory procedure has been called from EditionDAL." );

                return inventory;
            }
        }

        public struct Inventory
        {
            public int CurrentStock;
            public int InitialStock;
        }
    }
}
