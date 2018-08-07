using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM.IDAL
{
    public interface IRepository<TEntity>
    {
        #region 属性
        IQueryable<TEntity> Entities { get; }
        #endregion

        #region 公共方法
        int Insert(TEntity entity);

        int Insert(IEnumerable<TEntity> entities);

        int Delete(object id);

        int Delete(TEntity entity);

        int Delete(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        TEntity GetByKey(object key);
        #endregion
    }
}
