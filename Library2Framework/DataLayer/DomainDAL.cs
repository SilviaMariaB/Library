﻿using Library2Framework.DomainLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DataLayer
{
    public class DomainDAL
    {
        public static List<Domain> GetDomains()
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("GetDomains", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //deschidem conexiunea la BD        
                con.Open();

                //creem o colectie in care sa memoram rezultatele procedurii stocate
                List<Domain> result = new List<Domain>();

                //apelam efectiv procedura si depunem rezultatul in variabila reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Domain()
                        {
                            ID = reader.GetInt32(0),
                            DomainName = reader.GetString(1),
                            ParentName = reader.IsDBNull(2) == true ? "NULL" : reader.GetString(2)
                        }
                 );
                }
                reader.Close();
                return result;
            }

        }

        public static void AddDomain(Domain domain)
        {
            using (SqlConnection con = DBConnection.Connection)
            {

                //creem o variabila cmd unde transmitem numele procedurii stocate si conexiunea la BD
                //si o setam ca fiind de tip stored procedure
                SqlCommand cmd = new SqlCommand("AddDomain", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter domainName = new SqlParameter("@Name", domain.DomainName);
                SqlParameter parentName = new SqlParameter("@Parent", domain.ParentName);


                cmd.Parameters.Add(domainName);
                cmd.Parameters.Add(parentName);


                //deschidem conexiunea la BD        
                con.Open();
                //creem o colectie in care sa memoram rezultatele procedurii stocate

                cmd.ExecuteNonQuery();

            }
        }

        public static Boolean CheckDomain(string domainName)
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
                return counter == 0 ? false : true;
            }
        }
    }


}