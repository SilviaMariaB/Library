// <copyright file="AuthorDAL.cs" company="Transilvania University of Brasov">
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

    public class AuthorDAL
    {
        public static List<Author> GetAuthorsForBook(string bookName, int publicationYear, string publishingHouseName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                // creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                // si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetAuthorsForBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookNameSql = new SqlParameter("@BookName", bookName);
                SqlParameter publicationYearSql = new SqlParameter("@PublicationYear", publicationYear);
                SqlParameter publishingHouseNameSql = new SqlParameter("@PublishingHouseName", publishingHouseName);

                cmd.Parameters.Add(bookNameSql);
                cmd.Parameters.Add(publicationYearSql);
                cmd.Parameters.Add(publishingHouseNameSql);

                // deschidem conexiunea la BD
                con.Open();

                // creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Author> result = new List<Author>();

                // apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Author()
                        {
                            ID = reader.GetInt32(0),
                            AuthorName = reader.GetString(1),
                        });
                }

                reader.Close();
                return result;
            }
        }

        public static bool CheckAuthor(Author author)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForAuthor", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter authorName = new SqlParameter("@Name", author.AuthorName);

                cmd.Parameters.Add(authorName);

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