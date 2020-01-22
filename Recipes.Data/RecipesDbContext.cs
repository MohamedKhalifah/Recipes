using Microsoft.EntityFrameworkCore;
using Recipes.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
