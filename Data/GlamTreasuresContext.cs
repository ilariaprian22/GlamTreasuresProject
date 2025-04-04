﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlamTreasures.Models;
using GlamTreasures.Data;

namespace GlamTreasures.Data
{
    public class GlamTreasuresContext : IdentityDbContext<IdentityUser>
    {
        public GlamTreasuresContext(DbContextOptions<GlamTreasuresContext> options)
            : base(options)
        {
        }

        public DbSet<GlamTreasures.Models.JewelryItem> JewelryItem { get; set; } = default!;
        public DbSet<GlamTreasures.Models.Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
        public DbSet<GlamTreasures.Models.Set> Set { get; set; } = default!;
     
    }
   
}
