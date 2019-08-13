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
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
       // public string BrandName { get; set; }
        public bool Decomissioned { get; set; }
    }
}