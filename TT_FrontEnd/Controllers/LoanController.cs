using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.Models;

namespace TT_FrontEnd.Controllers
{
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

              //  loan = response.Content.ReadAsAsync<Loan>().Result;
              //  response = WebClient.ApiClient.GetAsync($"RentalItemsById/{loan.LoanID}").Result;

            
                //TODO - Redirect towards edit

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Loan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region Helper Methods


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

        public IEnumerable<SelectListItem> GetAvailableTools()
        {

            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Tool").Result;
            IList<Tool> tools = response.Content.ReadAsAsync<IList<Tool>>().Result;
                 
            //Select tools by weather they have been loaned, and if they have been returned.
            List<SelectListItem> toolList = tools
                            .Where(w => {
                                var loans = w.LoanTools;
                                int outloans = loans.Where(l => l.Loan.DateReturned == null).Count();
                                return outloans > 0 ? true: false ;
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
