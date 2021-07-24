using Microsoft.EntityFrameworkCore;
using OderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Driver> drivers { get; set; }
        

        }
    }

