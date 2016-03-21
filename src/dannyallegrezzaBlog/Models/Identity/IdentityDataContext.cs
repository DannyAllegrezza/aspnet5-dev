using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

// This class inherits from IdentityDbContext of type "ApplicationUser", which is a custom created class I have made in the Identity folder

namespace dannyallegrezzaBlog.Models.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext()
        {
            Database.EnsureCreated(); // Tells the DataContext to ensure the DB is created.
        }
    }
}
