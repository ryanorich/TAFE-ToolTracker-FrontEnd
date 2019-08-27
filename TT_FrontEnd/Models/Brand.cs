using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Brand
    {
        [Display(Name = "Brand ID")]
        public int BrandID { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public virtual ICollection<Tool> Tools { get; set; }

    }
}