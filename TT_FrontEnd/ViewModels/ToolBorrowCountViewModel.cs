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
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public int BorrowCount { get; set; }
        public string picFileName { get; set; }

    }
}