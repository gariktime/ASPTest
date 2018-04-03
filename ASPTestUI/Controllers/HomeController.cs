using ASPTest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPTestUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController(IUserService userServ)
        {
            userService = userServ;
        }

        public ActionResult Index()
        {
            var users = userService.GetUsers();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}