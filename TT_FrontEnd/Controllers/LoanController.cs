﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
	/// <summary>
	/// Controller for Loans
	/// </summary>
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Loan").Result;

            IEnumerable<Loan> loans = response.Content.ReadAsAsync<IEnumerable<Loan>>().Result;

            return View(loans);
        }

        // GET: Loan/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Loan/{id}").Result;
            var loan = response.Content.ReadAsAsync<Loan>().Result;

            return View(loan);
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            var loan = new Loan();

            loan.LoanID = 0;
            loan.DateBorrowed = DateTime.Now;
            loan.Workspaces = GetWorkspaces();
            loan.Borrowers = GetBorrowers();

            return View(loan);
        }

        // POST: Loan/Create
        [HttpPost]
        public ActionResult Create(Loan loan)
        {
            try
            {
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("Loan", loan).Result;

                loan = response.Content.ReadAsAsync<Loan>().Result;


				TempData["SuccessMessage"] = "Loan created sucseefully.";
				return RedirectToAction("Edit", new { id = loan.LoanID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Loan/{id}").Result;
            var loan = response.Content.ReadAsAsync<Loan>().Result;

            loan.Borrowers = GetBorrowers();
            loan.Workspaces = GetWorkspaces();

            return View(loan);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Loan loan)
        {
            try
            {
                // TODO: Add update logic here

                HttpResponseMessage response = WebClient.ApiClient.PutAsJsonAsync($"Loan/{id}", loan).Result;
				if (response.IsSuccessStatusCode)
				{
					TempData["SuccessMessage"] = "Loan updated sucseefully.";
					return RedirectToAction("Index");
				}
					return View(loan);
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"Loan/{id}").Result;
            var loan = response.Content.ReadAsAsync<Loan>().Result;

            return View(loan);
        }

        // POST: Loan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Loan loan)
        {
            try
            {
              
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"Loan/{id}").Result;
				TempData["SuccessMessage"] = "Loan deleted sucseefully.";
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Add Loaned Tool - Get
        public ActionResult AddLoanedTool(int loanID)
        {
            var loanTool = new LoanTool();
            var tools = GetAvailableTools();
            loanTool.LoanID = loanID;
            loanTool.AvailableTools = tools;

            return View(loanTool);
        }

        // Add Loaned Tool - Post
        [HttpPost]
        public ActionResult AddLoanedTool(LoanTool loanTool)
        {
            try
            {
                int id = loanTool.LoanID;
                HttpResponseMessage response = WebClient.ApiClient.PostAsJsonAsync("LoanTool", loanTool).Result;
				TempData["SuccessMessageEdit"] = "Loan Tool added sucseefully.";
				return RedirectToAction("Edit", new { id });
            }
            catch
            {
                // TODO - Update response message
                return View("No record found...");
            }
        }

        // Remove Loaned Tool - Get
        public ActionResult RemoveLoanedTool(int id)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync($"LoanTool/{id}").Result;
            var loanTool = response.Content.ReadAsAsync<LoanTool>().Result;

            return View(loanTool);
        }

        // Remove Loaned Tool - Post
        [HttpPost]
        public ActionResult RemoveLoanedTool(int id, LoanTool loanTool)
        {
            try
            {
	
                HttpResponseMessage response = WebClient.ApiClient.DeleteAsync($"LoanTool/{id}").Result;
				TempData["SuccessMessageEdit"] = "Loan Tool removed sucseefully.";
				var loanToolDeleted = response.Content.ReadAsAsync<LoanTool>().Result;
				return RedirectToAction("Edit", new { id = loanToolDeleted.LoanID });
            }
            catch (Exception e)
            {
                return View();
            }
        }
        
		#region Helper Methods

		// Gets a list for a Borrowers drop-down selection
        public IEnumerable<SelectListItem> GetBorrowers()
        {

            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Borrower").Result;
            IList<Borrower> borrowers = response.Content.ReadAsAsync<IList<Borrower>>().Result;

            List<SelectListItem> borrowerList = borrowers
                            .OrderBy(o => o.BorrowerName)
                            .Select(c => new SelectListItem
                            { Value = c.BorrowerID.ToString(),Text = c.BorrowerName                                                    }
                                    ).ToList();

            return new SelectList(borrowerList, "Value", "Text");
        }

		// Gets a list for a Workspaces drop-down selection
        public IEnumerable<SelectListItem> GetWorkspaces()
        {

            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Workspace").Result;
            IList<Workspace> workspaces= response.Content.ReadAsAsync<IList<Workspace>>().Result;

            List<SelectListItem> workspaceList = workspaces
                            .OrderBy(o => o.WorkspaceName)
                            .Select(w => new SelectListItem
                            { Value = w.WorkspaceID.ToString(), Text = w.WorkspaceName }
                                    ).ToList();

            return new SelectList(workspaceList, "Value", "Text");
        }

		// Gets a list for a Tools drop-down selection
        public IEnumerable<SelectListItem> GetTools()
        {

            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Tool").Result;
            IList<Tool> tools = response.Content.ReadAsAsync<IList<Tool>>().Result;

            List<SelectListItem> toolList = tools
                            .OrderBy(o => o.ToolName)
                            .Select(t => new SelectListItem
                            { Value = t.ToolID.ToString(), Text = t.ToolName }
                                    ).ToList();

            return new SelectList(toolList, "Value", "Text");
        }

		// Gets a list for a Tools drop-down, where the tool is not borrowed, and is not decomissioned
        public IEnumerable<SelectListItem> GetAvailableTools()
        {

            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Tool").Result;
            IList<Tool> tools = response.Content.ReadAsAsync<IList<Tool>>().Result;
                 
            //Count the numer of times a tool is part of a loan that has not been returned, and if 
            // it is more then 0, an the tool is decomisssioned, then it is available for loaing.
            List<SelectListItem> toolList = tools
                            .Where(w => {
                                var loans = w.LoanTools;
                                int outloans = loans.Where(l => l.Loan.DateReturned == null).Count();
                            return (outloans > 0) || (w.Decomissioned != false) ? false: true ;
                            })
                            .OrderBy(o => o.ToolName)
                            .Select(t => new SelectListItem
                            { Value = t.ToolID.ToString(), Text = t.ToolName }
                                    ).ToList();

            return new SelectList(toolList, "Value", "Text");
        }

        #endregion

    }
}
