using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.ViewModels
{
    public class TooListlViewModel
    {
        [Key]
        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string BrandName { get; set; }
        public bool Decomissioned { get; set; }
    }
}