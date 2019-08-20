using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TT_FrontEnd.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int BorrowerID { get; set; }
        public int WorkspaceID { get; set; }
        public System.DateTime DateBorrowed { get; set; }
        public System.DateTime? DateReturned { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Workspace Workspace { get; set; }

        public virtual ICollection<LoanTool> LoanTools { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }
        public IEnumerable<SelectListItem> Workspaces { get; set; }
        
    }
}