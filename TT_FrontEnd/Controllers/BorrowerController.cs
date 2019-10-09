using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
	/// <summary>
	/// Controller for Borrowers
	/// </summary>
    public class BorrowerController : Controller
    {
        // GET: Borrower
        public ActionResult Index()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Borrower").Result;
            IEnumerable<Borrower> borrowers = response.Content.ReadAsAsync<IEnumerable<Borrower>>().Result;
            return View(borrowers);
        }

        // GET: Borrower/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Borrower/{id}").Result;
            var borrower = response.Content.ReadAsAsync<Borrower>().Result;
            return View(borrower);
        }

        // GET: Borrower/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Borrower/Create
        [HttpPost]
        public ActionResult Create(Borrower borrower)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Borrower", borrower).Result;

				TempData["SuccessMessage"] = "Borrower created sucseefully.";

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Borrower/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Borrower/{id}").Result;
            var borrower = response.Content.ReadAsAsync<Borrower>().Result;
            return View(borrower);
        }

        // POST: Borrower/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Borrower borrower)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Borrower/{id}", borrower).Result;

				if (response.IsSuccessStatusCode)
				{
					TempData["SuccessMessage"] = "Borrower updated sucseefully.";
					return RedirectToAction("Index");
				}
                return View(borrower);
            }
            catch
            {
                return View();
            }
        }

        // GET: Borrower/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Borrower/{id}").Result;
            var borrower = response.Content.ReadAsAsync<Borrower>().Result;
			
			return View(borrower);
        }

        // POST: Borrower/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Borrower borrower)
        {
			HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Loan").Result;
			IEnumerable<Loan> loans = response.Content.ReadAsAsync<IEnumerable<Loan>>().Result;

			if (loans.Count(l => l.BorrowerID == id) > 0)
            {// Workspace is used in a loan - cannot delete
                TempData["FailureMessage"] = "Cannot delete Borrower that has been used in a loan.";
                return RedirectToAction("Index");
            }

            try
            {
                 response = WebClient.ApiClient.DeleteAsync($"Borrower/{id}").Result;
				TempData["SuccessMessage"] = "Borrower deleted sucseefully.";
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
