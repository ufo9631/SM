using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace SM.DAL
{
    public static class DataBaseConfig
    {
        //private static string MysqlConnectionString = "Database=mysql_test;Data Source=localhost;User Id=root;Password=Keytop:wabjtam!;CharSet=utf8;port=3306";
        ////private static string DefaultRedisString = "localhost, abortConnect=false";
        //// private static ConnectionMultiplexer redis;
        //private static IDbConnection GetDbConnection(this ConnectionStringSettings connectionStringSettings)
        //{
        //    if (connectionStringSettings != null && (string.IsNullOrEmpty(connectionStringSettings.ConnectionString) || string.IsNullOrEmpty(connectionStringSettings.ProviderName))) throw new Exception("数据库链接字符串配置不正确！");
        //    var settings = connectionStringSettings == null ? DefaultConnectionStringSettings : connectionStringSettings;
        //    var factory = System.Data.Common.DbProviderFactories.GetFactory(settings.ProviderName);
        //    var connection = factory.CreateConnection();
        //    connection.ConnectionString = settings.ConnectionString;
        //    return connection;

        //}
    }
}
