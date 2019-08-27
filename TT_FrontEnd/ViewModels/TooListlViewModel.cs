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
        [Display(Name = "Tool ID")]
        public int ToolId { get; set; }
        [Display(Name = "Tool")]
        public string ToolName { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Decomissioned")]
        public bool Decomissioned { get; set; }
        [Display(Name = "Picture File Name")]
        public string picFileName { get; set; }
    }
}