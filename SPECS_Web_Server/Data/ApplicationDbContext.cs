using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPECS_Web_Server.Models;

namespace SPECS_Web_Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<AlexaSession> AlexaSessions { get; set; }
        public DbSet<DevicePermission> Devices { get; set; }
        public DbSet<Fulfillment> Fulfillments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<AlexaSession>()
                .HasOne(s => s.ApplicationUser)
                .WithMany(a => a.AlexaSessions);

            builder.Entity<Fulfillment>()
                .HasOne(u => u.ApplicationUser)
                .WithMany(f => f.Fulfillments);
        }
    }
}
