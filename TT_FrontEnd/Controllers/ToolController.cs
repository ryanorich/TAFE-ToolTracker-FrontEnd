﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;
using TT_FrontEnd.ViewModels;

namespace TT_FrontEnd.Controllers
{
    public class ToolController : Controller
    {
        // GET: Tool
        public ActionResult Index()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Tool").Result;
            IEnumerable<Tool> tools = response.Content.ReadAsAsync<IEnumerable<Tool>>().Result;

            response = WebClient.ApiClient.GetAsync("Brand").Result;
            IList<Brand> brands = response.Content.ReadAsAsync<IList<Brand>>().Result;

            var toolViewModel = tools.Select(t => new TooListlViewModel
            {
                ToolId = t.ToolID,
                ToolName = t.ToolName,
                BrandName = brands.Where(b => b.BrandID == t.BrandID)
                                  .Select(u => u.BrandName)
                                  .FirstOrDefault(),
                // converting from bool? to bool (assuming null is false)
                Decomissioned = t.Decomissioned == true ? true : false

            }
            ).ToList();

            return View(toolViewModel);
        }

        // GET: Tool/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tool/{id}").Result;
            Tool tool = response.Content.ReadAsAsync<Tool>().Result;

            response = WebClient.ApiClient.GetAsync(@"Brand").Result;
            IEnumerable<Brand> brands = response.Content.ReadAsAsync<IEnumerable<Brand>>().Result;

            var toolListViewModel = new TooListlViewModel
            {
                ToolId = tool.ToolID,
                ToolName = tool.ToolName,
                BrandName = brands.Where(b => tool.BrandID == b.BrandID).Select(b => b.BrandName).FirstOrDefault(),
                Decomissioned = (bool)tool.Decomissioned
            };

            return View(toolListViewModel);
        }

        // GET: Tool/Create
        public ActionResult Create()
        {
            var tool = new Tool();

            tool.ToolID = 0;
            tool.Decomissioned = false;
            tool.Brands = GetBrands();

            return View(tool);
        }

        // POST: Tool/Create
        [HttpPost]
        public ActionResult Create(Tool tool)
        {
            try
            {

                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Tool", tool).Result;


                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return View(tool);
            }
            catch
            {
                return View();
            }
        }

        // GET: Tool/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tool/{id}").Result;
            var tool = response.Content.ReadAsAsync<Tool>().Result;

            tool.Brands = GetBrands();

            return View(tool);
        }

        // POST: Tool/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tool tool)
        {
            try
            {

                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Tool/{id}", tool).Result;
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return View(tool);
            }
            catch
            {
                return View();
            }
        }

        // GET: Tool/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Tool/{id}").Result;
            Tool tool = response.Content.ReadAsAsync<Tool>().Result;

            response = WebClient.ApiClient.GetAsync(@"Brand").Result;
            IEnumerable<Brand> brands = response.Content.ReadAsAsync<IEnumerable<Brand>>().Result;

            var toolListViewModel = new TooListlViewModel
            {
                ToolId = tool.ToolID,
                ToolName = tool.ToolName,
                BrandName = brands.Where(b => tool.BrandID == b.BrandID).Select(b => b.BrandName).FirstOrDefault(),
                Decomissioned = (bool)tool.Decomissioned
            };

            return View(toolListViewModel);




        }

        // POST: Tool/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tool tool)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Tool/{id}").Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IEnumerable<SelectListItem> GetBrands()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Brand").Result;
            IList<Brand> brands = response.Content.ReadAsAsync<IList<Brand>>().Result;

            List<SelectListItem> brandList = brands
                                                .OrderBy(o => o.BrandID)
                                                .Select(b => new SelectListItem
                                                {
                                                    Value = b.BrandID.ToString(),
                                                    Text = b.BrandName

                                                }
                                                ).ToList();

            return new SelectList(brandList, "Value", "Text");

        }
    }
}