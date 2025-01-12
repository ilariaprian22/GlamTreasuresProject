using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Models;

namespace GlamTreasures.Data
{
    public class GlamTreasuresContext : DbContext
    {
        public GlamTreasuresContext (DbContextOptions<GlamTreasuresContext> options)
            : base(options)
        {
        }

        public DbSet<GlamTreasures.Models.JewelryItem> JewelryItem { get; set; } = default!;
        public DbSet<GlamTreasures.Models.Category> Category { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
