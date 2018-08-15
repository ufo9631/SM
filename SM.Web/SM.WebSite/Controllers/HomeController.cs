using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using SM.Common;
using SM.IBLL;

namespace SM.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public IUserBLL UserBLL { get; set; }

        public HomeController(IUserBLL _userBLL)
        {
            UserBLL = _userBLL;
        }

        public IActionResult Index()
        {
            LogUtils.Info("sdfsdfsdf");
            return View();
        }
    }
}