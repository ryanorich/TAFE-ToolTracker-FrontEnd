using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace TT_FrontEnd.Models
{
    public class Tool
    {
        [Display(Name = "Tool ID")]
        public int ToolID { get; set; }
        [Display(Name = "Tool")]
        public string ToolName { get; set; }
        [Display(Name = "Decomissioned")]
        public bool Decomissioned { get; set; }
        [Display(Name = "Picture Name")]
        public string picFileName { get; set; }
        [Display(Name = "Brand ID")]
        public int BrandID { get; set; }
        
        public virtual Brand Brand { get; set; }
        public virtual ICollection<LoanTool> LoanTools { get; set; }

        //For Selection List
        public IEnumerable<SelectListItem> Brands { get; set; }

    }
}