using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TT_FrontEnd.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public Nullable<System.DateTime> DateBorrowed { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Workspace Workspace { get; set; }



        public virtual ICollection<LoanTool> LoanTools { get; set; }

    }
}