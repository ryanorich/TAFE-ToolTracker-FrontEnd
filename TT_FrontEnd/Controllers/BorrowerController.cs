using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
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
                    return RedirectToAction("Index");
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
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Borrower/{id}").Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
