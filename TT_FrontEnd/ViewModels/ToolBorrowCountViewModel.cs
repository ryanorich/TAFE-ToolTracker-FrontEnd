using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.ViewModels
{
    public class ToolBorrowCountViewModel
    {
        [Key]
		[Display (Name ="Tool ID")]
        public int ToolID { get; set; }
		[Display(Name = "Tool Name")]
		public string ToolName { get; set; }
		[Display(Name = "Times Borrowed")]
		public int BorrowCount { get; set; }
		public string picFileName { get; set; }
    }
}