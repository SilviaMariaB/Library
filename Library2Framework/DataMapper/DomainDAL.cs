﻿// <copyright file="DomainDAL.cs" company="PlaceholderCompany">
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

    public class DomainDAL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DomainDAL));

        public static List<Domain> GetDomains()
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                // creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                // si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetDomains", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

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
                            ID = reader.GetInt32(0),
                            DomainName = reader.GetString(1),
                            ParentName = reader.IsDBNull(2) == true ? "NULL" : reader.GetString(2),
                        });
                }

                reader.Close();
                log.Info("GetDomains procedure has been called from DomainDAL.");
                return result;
            }
        }

        public static void AddSubdomain(Domain domain)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubdomain", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter domainName = new SqlParameter("@Name", domain.DomainName);
                SqlParameter parentName = new SqlParameter("@Parent", domain.ParentName);

                cmd.Parameters.Add(domainName);
                cmd.Parameters.Add(parentName);

                con.Open();

                cmd.ExecuteNonQuery();
            }

            log.Info("AddSubdomain procedure has been called from DomainDAL.");
        }

        public static void AddDomain(Domain domain)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddDomain", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter domainName = new SqlParameter("@Name", domain.DomainName);

                cmd.Parameters.Add(domainName);

                con.Open();

                cmd.ExecuteNonQuery();
            }

            log.Info("AddDomain procedure has been called from DomainDAL.");
        }

        public static bool CheckDomain(string domainName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetIdForDomain", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter domainNameSQL = new SqlParameter("@DomainName", domainName);

                cmd.Parameters.Add(domainNameSQL);

                con.Open();
                int counter = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }

                reader.Close();
                log.Info("GetIdForDomain procedure has been called from DomainDAL.");

                return counter == 0 ? false : true;
            }
        }

        public static string GetParentForDomain(string childName)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetParentForDomain", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter childNameSql = new SqlParameter("@childName", childName);

                cmd.Parameters.Add(childNameSql);

                con.Open();

                string result = string.Empty;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }

                reader.Close();

                if (result.Equals(string.Empty))
                {
                    return null;
                }

                log.Info("GetParentForDomain procedure has been called from DomainDAL.");

                return result;
                }
        }
    }
}
