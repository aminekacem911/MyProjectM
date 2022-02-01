using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProjectM.Areas.Identity.Data;
using MyProjectM.Models;

namespace MyProjectM.Data
{
    public class AuthContext : IdentityDbContext<MyProjectMUser>
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        //public AuthContext()
        //{
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MyProjectM.Models.Ticket> Ticket { get; set; }
        public DbSet<Contact> Contact { get; set; }


    }
}
