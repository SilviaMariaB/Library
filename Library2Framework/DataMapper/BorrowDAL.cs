using Library2Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DataMapper
{
    public static class BorrowDAL
    {
        public static List<Borrow> GetBorrowsForUser(string email)
        {
            using (SqlConnection con = DBConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetBorrowsForUser", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter emailSql = new SqlParameter("@UserEmail", email);
                
                cmd.Parameters.Add(emailSql);
                
                con.Open();
                
                List<Borrow> result = new List<Borrow>();
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Borrow()
                        {
                            BookName=reader.GetString(0),
                            PublicationYear=reader.GetInt32(1),
                            PublishingHouseName= reader.GetString(2),
                            StartDate=reader.GetDateTime(3),
                            EndDate=reader.GetDateTime(4),
                            Period=reader.GetInt32(5)
                        });
                }
                reader.Close();
                return result;
            }
        }
    }
}
