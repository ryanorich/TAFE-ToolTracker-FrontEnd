using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
    public class Test_EmptyController : Controller
    {
        // GET: Test_Empty
        public ActionResult Index()
        {
            return View();
        }
    }
}