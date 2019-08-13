using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Tool
    {
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public Nullable<bool> Decomissioned { get; set; }
        public string picFileName { get; set; }
        public virtual Brand Brand { get; set; }
    }
}