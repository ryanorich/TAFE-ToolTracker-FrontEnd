using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Borrower
    {
        [Display(Name = "Borrower ID")]
        public int BorrowerID { get; set; }
        [Display(Name = "Borrower")]
        public string BorrowerName { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}