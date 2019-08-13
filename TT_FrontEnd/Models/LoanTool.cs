using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class LoanTool
    {
        public int LoanToolID { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual Tool Tool { get; set; }
    }
}