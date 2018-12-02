using SM.IBLL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SM.BLL
{
    public abstract class BaseBLL<T> where T:class,new()
    {
        public IDAL.IRepository<T> DalInstance;

        public abstract void Initialize();
        public bool Delete(object id)
        {
           return DalInstance.Delete(id);
        }

        public bool Delete(T entity)
        {
            return DalInstance.Delete(entity);
        }

        public IList<T> GetAllList()
        {
            return DalInstance.GetAllList();
        }

        public T GetByKey(object key)
        {
            return DalInstance.GetByKey(key);
        }

        public IList<T> GetList(Expression<Func<T, bool>> lambWhere)
        {
            return DalInstance.GetList(lambWhere);
        }

        public IList<T> GetList(Expression<Func<T, bool>> lambWhere, int pageIndex, int pageSize, out int pageCount)
        {
            return DalInstance.GetList(lambWhere, pageIndex, pageSize, out pageCount);
        }

        public bool Insert(T entity)
        {
            return DalInstance.Insert(entity);
        }

        public bool Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
