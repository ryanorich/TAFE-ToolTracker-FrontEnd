using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TT_FrontEnd.ViewModels;

namespace TT_FrontEnd.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [HttpGet]
        public ActionResult GetLoanedToolsReport(string criteria)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetLoanedToolsReport").Result;

            IEnumerable<LoanedToolsViewModel> loanedToolsReport = response.Content.ReadAsAsync<IEnumerable<LoanedToolsViewModel>>().Result;

            
            return View(loanedToolsReport);
        }

        [HttpGet]
        public ActionResult GetToolInventoryReport(string criteria)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetToolInventoryReport").Result;

            IEnumerable<ToolInventoryViewModel> toolInventoryReport = response.Content.ReadAsAsync<IEnumerable<ToolInventoryViewModel>>().Result;


            return View(toolInventoryReport);
        }
    }
}