using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracaMagisterska.Models;

namespace PracaMagisterska.Data
{
    public class PracaMagisterskaContext : DbContext
    {
        public PracaMagisterskaContext (DbContextOptions<PracaMagisterskaContext> options)
            : base(options)
        {
        }

        public DbSet<PracaMagisterska.Models.tests> testTable { get; set; }
        public DbSet<PracaMagisterska.Models.testWithForeignKey> foreign1 {get; set; }
        public DbSet<PracaMagisterska.Models.testWithForeignKey> foreign2 { get; set; }
    }
}
