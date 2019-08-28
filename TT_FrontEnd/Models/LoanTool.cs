using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TT_FrontEnd.Models
{
    public class LoanTool
    {
        public int LoanToolID { get; set; }
        public int LoanID { get; set; }
        public int ToolID { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual Tool Tool { get; set; }

        public IEnumerable<SelectListItem> AvailableTools { get; set; }

    }
}