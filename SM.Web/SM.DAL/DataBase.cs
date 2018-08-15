using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace SM.DAL
{

    public static class DataBase
    {

        public static IDbConnection GetDbConnection(string connectionString)
        {
            var factory = System.Data.Common.DbProviderFactories.GetFactory(connectionString);
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
