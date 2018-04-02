using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPECS_Web_Server.Models;

namespace SPECS_Web_Server.Data
{
    public class SPECSDbContext : DbContext
    {
        public DbSet<ApplicationUser> Members { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<AlexaSession> AlexaSessions { get; set; }
        public DbSet<DevicePermission> Devices { get; set; }
        public DbSet<MedicalSensorData> MedicalData { get; set; }

        public SPECSDbContext(){
            
        }

        public SPECSDbContext(DbContextOptions<SPECSDbContext> options)
            : base(options)
        {
        }
    }
}