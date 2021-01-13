using TractionTools.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TractionTools.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) :                                                base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeIngredient>().HasKey(ri => new { ri.Id });
            modelBuilder.Entity<RecipeIngredient>().Property(ri => ri.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Ingredient>().HasKey(i => new { i.Id });
            modelBuilder.Entity<Ingredient>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Recipe>().Property(e => e.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
