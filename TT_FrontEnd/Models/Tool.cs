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
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public bool Decomissioned { get; set; }
        public string picFileName { get; set; }

		public int BrandID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<LoanTool> LoanTools { get; set; }

        //For Selection List
        public IEnumerable<SelectListItem> Brands { get; set; }

    }
}