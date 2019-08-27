using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.ViewModels
{
    public class LoanedToolsViewModel
    {
        [Key]
        [Display(Name ="Tool ID")]
        public int ToolID { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Tool")]
        public string ToolName { get; set; }
        [Display(Name = "Loan ID")]
        public int LoanID { get; set; }
        [Display(Name = "Workspace")]
        public string WorkspaceName { get; set; }
        [Display(Name = "Date Returned")]
        public string BorrowerName { get; set; }
        [Display(Name = "Date Borrowed")]
        public DateTime DateBorrowed { get; set; }
    }
}