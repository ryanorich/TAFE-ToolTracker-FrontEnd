using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
	public class BrandController : Controller
	{
		// GET: Brand
		public ActionResult Index()
		{
			HttpResponseMessage response = WebClient.ApiClient.GetAsync("Brand").Result;

			IEnumerable<Brand> brands = response.Content.ReadAsAsync<IEnumerable<Brand>>().Result;

			return View(brands);
		}

		// GET: Brand/Details/5
		public ActionResult Details(int id)
		{
			HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Brand/{id}").Result;
			var brand = response.Content.ReadAsAsync<Brand>().Result;
			return View(brand);
		}

		// GET: Brand/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Brand/Create
		[HttpPost]
		public ActionResult Create(Brand brand)
		{
			try
			{
				HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Brand", brand).Result;
				TempData["SuccessMessage"] = "Brand created sucseefully.";
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Brand/Edit/5
		public ActionResult Edit(int id)
		{
			HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Brand/{id}").Result;
			var brand = response.Content.ReadAsAsync<Brand>().Result;
			return View(brand);
		}

		// POST: Brand/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Brand brand)
		{
			try
			{
				HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Brand/{id}", brand).Result;

				if (response.IsSuccessStatusCode)
				{
					TempData["SuccessMessage"] = "Brand updated sucseefully.";
					return RedirectToAction("Index");
				}
				return View(brand);
			}
			catch
			{
				return View();
			}
		}

		// GET: Brand/Delete/5
		public ActionResult Delete(int id)
		{
			HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Brand/{id}").Result;
			var brand = response.Content.ReadAsAsync<Brand>().Result;
			return View(brand);
		}

		// POST: Brand/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, Brand brand)
		{
			try
			{
				HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Brand/{id}").Result;
				TempData["SuccessMessage"] = "Brand deleted sucseefully.";
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
