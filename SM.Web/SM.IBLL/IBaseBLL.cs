using System;
using System.Collections.Generic;
using System.Text;

namespace SM.IBLL
{
    public interface IBaseBLL<TEntity>
    {
        int Insert(TEntity entity);
    }
}
