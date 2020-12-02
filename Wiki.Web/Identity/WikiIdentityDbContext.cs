using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.Web.Identity
{
    public class WikiIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public WikiIdentityDbContext(): base("FilmeDbContext")
        {
        }

        public System.Data.Entity.DbSet<Wiki.Web.ViewModels.User.UserViewModel> UserViewModels { get; set; }
    }
}