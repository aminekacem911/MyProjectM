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
        public AuthContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        private readonly string _connString = "Server=(LocalDB)\\MSSQLLocalDB;Database=MyProjectM;Trusted_Connection=True;MultipleActiveResultSets=True";

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        public DbSet<MyProjectM.Models.Ticket> Ticket { get; set; }
        public DbSet<Contact> Contact { get; set; }
        
        public DbSet<MyProjectM.Models.Member> Member { get; set; }
       // public DbSet<Areas.Identity.Data.MyProjectMUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

  
        }

       
    }
}
