// <copyright file="UserDAL.cs" company="PlaceholderCompany">
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
    using Library2Framework.Utils;

    public class UserDAL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserDAL));
        
        public static List<User> GetLibrarians()
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetLibrarians", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                con.Open();

                List<User> result = new List<User>();

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
                            Librarian = reader.GetInt32(7) == 0 ? false : true,
                        });
                }

                reader.Close();
                    log.Info("GetLibrarians procedure has been called from UserDAL." );
                return result;
            }
        }

        public static List<User> GetReaders()
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetReaders", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                con.Open();

                List<User> result = new List<User>();

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
                            Librarian = reader.GetInt32(7) == 0 ? false : true,
                        });
                }

                reader.Close();
                    log.Info("GetReaders procedure has been called from UserDAL." );
                return result;
            }
        }

        public static void AddLibrarian(User librarian, bool isReader)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddLibrarian", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter firstName = new SqlParameter("@FirstName", librarian.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", librarian.LastName);
                SqlParameter address = new SqlParameter("@Address", librarian.Address);
                SqlParameter phone = new SqlParameter("@Phone", librarian.PhoneNumber);
                SqlParameter email = new SqlParameter("@Email", librarian.Email);
                SqlParameter isReaderSql = new SqlParameter("@IsReader", isReader == true ? 1 : 0);

                cmd.Parameters.Add(firstName);
                cmd.Parameters.Add(lastName);
                cmd.Parameters.Add(address);
                cmd.Parameters.Add(phone);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(isReaderSql);

                con.Open();

                cmd.ExecuteNonQuery();
            }
                log.Info("AddLibrarian procedure has been called from UserDAL." );
        }

        public static void AddReader(User reader)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddReader", con)
                {
                    CommandType = CommandType.StoredProcedure,
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

                con.Open();

                cmd.ExecuteNonQuery();
            }
                log.Info("AddReader procedure has been called from UserDAL." );
        }

        public static bool CheckUser(string email)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForUser", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter emailSql = new SqlParameter("@Email", email);

                cmd.Parameters.Add(emailSql);

                con.Open();
                int counter = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }

                reader.Close();
                    log.Info("GetIdForUser procedure has been called from UserDAL." );
                return counter == 0 ? false : true;
            }
        }
    }
}