using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Workspace
    {
        public int WorkspaceID { get; set; }
        public string WorkspaceName { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}