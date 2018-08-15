using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SM.DAL
{
    public class BaseDAL<TEntity> where TEntity : class
    {
        public IConfiguration configuration { get; set; }
        public BaseDAL(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        //public int Insert(TEntity entity)
        //{
        //    int result = 0;
        //    using (IDbConnection conn = DataBase.GetDbConnection(""))
        //    {
        //      //  result=conn.Execute()
        //    }
        //}
    }
}
