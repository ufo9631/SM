
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SM.DAL
{

    public class DataBase
    {
        public IConfiguration configuration { get; set; }
        /// <summary>
        /// 链接字符串
        /// </summary>
        protected string ConnStr { get; set; }

        public DataBase(IConfiguration _configuration)
        {
            configuration = _configuration;
            ConnStr= configuration.GetConnectionString("MySqlConn");
        }
        public DataBase()
        { }
    }
}
