using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
    public class WorkspaceController : Controller
    {

        // GET: Workspace
        public ActionResult Index()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Workspace").Result;

            IEnumerable<Workspace> workspaces = response.Content.ReadAsAsync<IEnumerable<Workspace>>().Result;
            return View(workspaces);
        }

        // GET: Workspace/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Workspace/{id}").Result;
            var workspace = response.Content.ReadAsAsync<Workspace>().Result;
            return View(workspace);
        }

        // GET: Workspace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workspace/Create
        [HttpPost]
        public ActionResult Create(Workspace workspace)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Workspace", workspace).Result;
				TempData["SuccessMessage"] = "Workspace created sucseefully.";
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Workspace/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Workspace/{id}").Result;
            var workspace = response.Content.ReadAsAsync<Workspace>().Result;
            return View(workspace);
        }

        // POST: Workspace/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Workspace workspace)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Workspace/{id}", workspace).Result;
				if (response.IsSuccessStatusCode)
				{
					TempData["SuccessMessage"] = "Workspace updated sucseefully.";
					return RedirectToAction("Index");
				}
					return View(workspace);
            }
            catch
            {
                return View();
            }
        }

        // GET: Workspace/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Workspace/{id}").Result;
            var workspace = response.Content.ReadAsAsync<Workspace>().Result;
            return View(workspace);
        }

        // POST: Workspace/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Workspace/{id}").Result;
				TempData["SuccessMessage"] = "Workspace deleted sucseefully.";
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
