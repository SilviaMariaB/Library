// <copyright file="DBConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library2Framework.DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DBConnection
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        internal static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
    }
}
