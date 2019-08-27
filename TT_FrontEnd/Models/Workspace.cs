using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Workspace
    {
        [Display(Name = "Workspace ID")]
        public int WorkspaceID { get; set; }
        [Display(Name = "Workspace")]
        public string WorkspaceName { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}