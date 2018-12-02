using Microsoft.Extensions.Configuration;
using SM.IBLL;
using SM.IDAL;
using SM.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SM.BLL
{
    public class UserBLL : BaseBLL<T_User>, IUserBLL
    {
        public IUserDAL UserDAL { get; set; }
        public UserBLL(IUserDAL _UserDAL)
        {
            UserDAL = _UserDAL;
            Initialize();
        }
        public override void Initialize()
        {
            DalInstance = UserDAL;
        }
    }
}
