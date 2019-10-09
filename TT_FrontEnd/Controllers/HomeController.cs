using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TT_FrontEnd.Controllers
{
	/// <summary>
	/// Controller for default Home Page
	/// </summary>
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}

		public ActionResult Help()
		{
			ViewBag.Title = "Help Page";

			return View();
		}

	}
}
