using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class Brand
    {

        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Tool> Tools { get; set; }

    }
}