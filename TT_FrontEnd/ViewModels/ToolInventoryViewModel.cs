using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.ViewModels
{
    public class ToolInventoryViewModel
    {
        [Key]
        [Display(Name = "Tool ID")]
        public int ToolID { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Tool")]
        public string ToolName { get; set; }
        [Display(Name = "Decomissioned")]
        public bool Decomissioned { get; set; }
        [Display(Name = "Loaned")]
        public int Loaned { get; set; }
        [Display(Name = "Lastest Loan ID")]
        public int? Latest { get; set; }
        [Display(Name = "Loaned")]
        public bool isLoaned
        {
            get { return Loaned > 0; }
            set { }
        }
    }
}