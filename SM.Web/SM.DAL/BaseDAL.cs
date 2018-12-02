
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SM.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SM.DAL
{
    public abstract class BaseDAL<TEntity> : DataBase where TEntity : class, new()
    {
        /// <summary>
        /// 处理数据库的上下文
        /// </summary>
        public SqlSugarClient Db { get; set; }

        public SimpleClient<TEntity> DbContext { get; set; }


        public BaseDAL()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnStr,
                DbType = SqlSugar.DbType.MySql,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true //开启自动释放模式和ef原理一样
            });
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                LogUtils.Debug(Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };

            DbContext = new SimpleClient<TEntity>(Db);
        }
        public bool Delete(object id)
        {
            return DbContext.DeleteById(id);
        }

        public bool Delete(TEntity entity)
        {
            return DbContext.Delete(entity);
        }

        public TEntity GetByKey(object key)
        {
            return DbContext.GetById(key);
        }

        public bool Insert(TEntity entity)
        {
            return DbContext.Insert(entity);
        }
        public bool Insert(IEnumerable<TEntity> entities)
        {
            return DbContext.InsertRange(entities.ToArray());
        }
        public bool Update(TEntity entity)
        {
            return DbContext.Update(entity);
        }

        public IList<TEntity> GetAllList()
        {
            return DbContext.GetList();
        }
       
        public IList<TEntity> GetList(Expression<Func<TEntity,bool>> lambWhere)
        {
            return DbContext.GetList(lambWhere);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> lambWhere,int pageIndex,int pageSize,out int pageCount)
        {
            var p = new PageModel { PageIndex = pageIndex, PageSize = pageSize };

            var data= DbContext.GetPageList(lambWhere,p);
            pageCount = p.PageCount;
            return data;
        }

    }
}
