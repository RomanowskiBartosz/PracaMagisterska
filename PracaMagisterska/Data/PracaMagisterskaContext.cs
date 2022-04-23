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

        public DbSet<PracaMagisterska.Models.TS_price_PRICELIST_ACTIONS> TS_price_PRICELIST_ACTIONS { get; set; }
    }
}
