using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SM.IDAL
{
    public interface IRepository<TEntity>
    {
      
        #region 公共方法
        bool Insert(TEntity entity);

        bool Insert(IEnumerable<TEntity> entities);

        bool Delete(object id);

        bool Delete(TEntity entity);

        bool Update(TEntity entity);

        TEntity GetByKey(object key);
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAllList();
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> lambWhere);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> lambWhere, int pageIndex, int pageSize, out int pageCount);

        #endregion
    }
}
