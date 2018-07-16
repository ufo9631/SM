using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using SM.Common;

namespace SM.WebSite.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            LogUtils.Info("sdfsdfsdf");
            return View();
        }
    }
}