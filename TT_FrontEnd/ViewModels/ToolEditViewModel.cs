using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TT_FrontEnd.ViewModels
{
    public class ToolEditViewModel
    {
        [Key]
        [Display(Name = "Tool ID")]
        public int ToolId { get; set; }
        [Display(Name = "Tool")]
        public string ToolName { get; set; }
       // public string picFileName { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        // public string BrandName { get; set; }
        [Display(Name = "Decomissioned")]
        public bool Decomissioned { get; set; }
    }
}