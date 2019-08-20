using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.ViewModels
{
    public class ToolInventoryViewModel
    {
        [Key]
        public int ToolID { get; set; }
        public string BrandName { get; set; }
        public string ToolName { get; set; }
        public bool Decomissioned { get; set; }
        public int Loaned { get; set; }
        public int? Latest { get; set; }

        public bool isLoaned
        {
            get { return Loaned > 0; }
            set { }
        }
    }
}