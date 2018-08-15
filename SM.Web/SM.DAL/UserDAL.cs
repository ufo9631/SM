using SM.IDAL;
using SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM.DAL
{
    public class UserDAL : BaseDAL<T_User>, IUserDAL
    {
        public IQueryable<T_User> Entities => throw new NotImplementedException();

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }

        public int Delete(T_User entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<T_User> entities)
        {
            throw new NotImplementedException();
        }

        public T_User GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public int Insert(T_User entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<T_User> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(T_User entity)
        {
            throw new NotImplementedException();
        }
    }
}
