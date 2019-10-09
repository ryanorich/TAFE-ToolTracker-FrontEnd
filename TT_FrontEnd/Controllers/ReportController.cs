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
	/// <summary>
	/// Controller for Reports
	/// </summary>
    public class ReportController : Controller
    {
        /// <summary>
		/// Retrieves and displayes the Loaned Tools Reprot data
		/// </summary>
		/// <param name="criteria">A search parameter used to filter the results</param>
		/// <returns>The Loaned Tool Report View</returns>
        [HttpGet]
        public ActionResult GetLoanedToolsReport(string criteria)
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetLoanedToolsReport").Result;
            IEnumerable<LoanedToolsViewModel> loanedToolsReport = response.Content.ReadAsAsync<IEnumerable<LoanedToolsViewModel>>().Result;
			TempData["LoanedTools"] = loanedToolsReport;
            return View(loanedToolsReport);
        }

		/// <summary>
		/// Retrieves and displayes the Tool Inventory data.
		/// </summary>
		/// <param name="criteria">A search parameter used to filter the results</param>
		/// <returns>The Tool Inventory View</returns>
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

		/// <summary>
		/// Exports the Loaned Tools report data as CSV file
		/// </summary>
		public void ExportLoanedTools()
		{
			List<LoanedToolsViewModel> loanedTools = TempData["LoanedTools"] as List<LoanedToolsViewModel>;

            // re-creating TempData to allow for exporting again.
            TempData["LoanedTools"] = loanedTools;
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

		/// <summary>
		/// Exports the Tool Inventory as CSV file
		/// </summary>
		public void ExportToolInventory()
		{
			List<ToolInventoryViewModel> toolInventory = TempData["ToolInventory"] as List<ToolInventoryViewModel>;
            // re-creating tool data in Temp Data to allow for re-exporting report
            TempData["ToolInventory"] = toolInventory;
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

        /// <summary>
		/// Retrieves a list of tools with a count of the number of times borrowed.
		/// </summary>
		/// <returns>IEnumerable with tool borrow count data</returns>
        public IEnumerable<ToolBorrowCountViewModel> GetToolBorrowCountData()
        {
            HttpResponseMessage response = WebClient.ApiClient.GetAsync("Report/GetToolBorrowCount").Result;
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountReport =
                response.Content.ReadAsAsync<IEnumerable<ToolBorrowCountViewModel>>().Result;
            return toolBorrowCountReport;
        }

        /// <summary>
		/// Creates and image of a bar chart of the loan count of all tools
		/// </summary>
		/// <returns>Chart as an image</returns>
        public ActionResult DrawToolBorrowCountChart()
        {
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountData = GetToolBorrowCountData();
			return View(toolBorrowCountData);
        }

		/// <summary>
		/// Displayes the tool borrow count data
		/// </summary>
		/// <returns></returns>
        public ActionResult GetToolBorrowCountReport()
        {
            IEnumerable<ToolBorrowCountViewModel> toolBorrowCountData = GetToolBorrowCountData();
			// reverse the order to Descending.
			// Note - ChartHelper breaks if order is changed in GetToolBorrowCountDate() or DrawToolBroowoCountChart()
            return View(toolBorrowCountData.Reverse());
        }

	}
}