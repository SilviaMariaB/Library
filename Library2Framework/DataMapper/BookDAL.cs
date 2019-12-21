// <copyright file="BookDAL.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

    public class BookDAL
    {
        public static bool CheckBook(string bookName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookNameSQL = new SqlParameter("@BookName", bookName);

                cmd.Parameters.Add(bookNameSQL);

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

        public static List<Domain> GetDomainsForBook(string bookName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                // creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                // si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetDomainsForBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookNameSql = new SqlParameter("@BookName", bookName);
                cmd.Parameters.Add(bookNameSql);

                // deschidem conexiunea la BD
                con.Open();

                // creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Domain> result = new List<Domain>();

                // apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Domain()
                        {
                            DomainName = reader.GetString(0),
                        });
                }

                reader.Close();
                return result;
            }
        }

        public static void AddDomainForBook(string domainName, string bookName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddDomainForBook", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter bookNameSql = new SqlParameter("@BookName", bookName);
                SqlParameter domainNameSql = new SqlParameter("@DomainName", domainName);

                cmd.Parameters.Add(bookNameSql);
                cmd.Parameters.Add(domainNameSql);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
