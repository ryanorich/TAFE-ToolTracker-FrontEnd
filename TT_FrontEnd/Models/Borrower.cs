using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Borrower
    {
        public int BorrowerID { get; set; }
        public string BorrowerName { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}