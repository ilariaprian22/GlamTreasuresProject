using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace GlamTreasures.Data
{
    public class GlamTreasuresContext : DbContext
    {
        public GlamTreasuresContext (DbContextOptions<GlamTreasuresContext> options)
            : base(options)
        {
        }

        public DbSet<GlamTreasures.Models.JewelryItem> JewelryItem { get; set; } = default!;
        public DbSet<GlamTreasures.Models.Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any additional model configuration here
        }
    }
}