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
        public int ToolID { get; set; }
        public string BrandName { get; set; }
        public string ToolName { get; set; }
        public int LoanID { get; set; }
        public string WorkspaceName { get; set; }
        public string BorrowerName { get; set; }
        public DateTime DateBorrowed { get; set; }
    }
}