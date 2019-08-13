using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TT_FrontEnd.Models
{
    public class TT_FrontEndContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TT_FrontEndContext() : base("name=TT_FrontEndContext")
        {
        }

        public System.Data.Entity.DbSet<TT_FrontEnd.Models.Borrower> Borrowers { get; set; }

        public System.Data.Entity.DbSet<TT_FrontEnd.Models.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<TT_FrontEnd.Models.Workspace> Workspaces { get; set; }
    }
}
