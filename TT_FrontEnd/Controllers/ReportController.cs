using System;
using System.Collections.Generic;
using System.IO;
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

			TempData["LoanedTools"] = loanedToolsReport;
            return View(loanedToolsReport);
        }

        [HttpGet]
        public ActionResult GetToolInventoryReport(string criteria)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetToolInventoryReport").Result;

            IEnumerable<ToolInventoryViewModel> toolInventoryReport = response.Content.ReadAsAsync<IEnumerable<ToolInventoryViewModel>>().Result;

			if (!string.IsNullOrWhiteSpace(criteria))
			{// There is criteria to filter
				toolInventoryReport = toolInventoryReport
										.Where(t => t.ToolName.ToLower().Contains(criteria.ToLower()) ||
													t.BrandName.ToLower().Contains(criteria.ToLower()))
										.ToList();
			}


			TempData["ToolInventory"] = toolInventoryReport;
			return View(toolInventoryReport);
        }

		public void ExportLoanedTools()
		{
			List<LoanedToolsViewModel> loanedTools = TempData["LoanedTools"] as List<LoanedToolsViewModel>;

			StringWriter sw = new StringWriter();

			sw.WriteLine("\"Brand\",\"Tool\",\"Loan ID\",\"Workspace\",\"Borrower\",\"Date Borrowed\"");

			Response.ClearContent();
			Response.AddHeader("content-disposition", "attachment; filename=LoanedTools.csv");
			foreach (var tool in loanedTools)
			{
				sw.WriteLine($"{tool.BrandName},{tool.ToolName},{tool.LoanID},{tool.WorkspaceName},{tool.BorrowerName},{tool.DateBorrowed}");
			}
			Response.Write(sw.ToString());
			Response.End();

		}

		public void ExportToolInventory()
		{
			List<ToolInventoryViewModel> toolInventory = TempData["ToolInventory"] as List<ToolInventoryViewModel>;

			StringWriter sw = new StringWriter();

			sw.WriteLine("\"Brand\",\"Tool\",\"Decomissioned\",\"Loaned\",\"Latest Loan ID\"");

			Response.ClearContent();
			Response.AddHeader("content-disposition", "attachment; filename=ToolInventory.csv");
			foreach (var tool in toolInventory)
			{
				sw.WriteLine($"{tool.BrandName},{tool.ToolName},{tool.Decomissioned},{tool.isLoaned},{tool.Latest}");
			}
			Response.Write(sw.ToString());
			Response.End();

		}

        // Retrieve report data form API
        public IEnumerable<ToolBorrowCountViewModel> GetToolBorrowCountData()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetToolBorrowCount").Result;
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountReport =
                response.Content.ReadAsAsync<IEnumerable<ToolBorrowCountViewModel>>().Result;

            return toolBorrowCountReport;
        }

        // Draw the Chart
        public ActionResult DrawToolBorrowCountChart()
        {
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountData = GetToolBorrowCountData();
			

			return View(toolBorrowCountData);
        }

        public ActionResult GetToolBorrowCountReport()
        {
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountData = GetToolBorrowCountData();
            return View(toolBorrowCountData.Reverse());
        }

	}
}