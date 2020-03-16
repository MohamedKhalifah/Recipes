using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Recipes.Core;

namespace Recipes.Data
{
    public class SqlRecipeData : IRecipeData
    {
        private readonly RecipesDbContext dbContext;

        public SqlRecipeData(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Commit()
        {
            int result = dbContext.SaveChanges();
            return result;
        }

        public void CreateRecipe(Recipe recipe)
        {
            dbContext.Recipes.Add(recipe);
        }

        public void DeleteRecipe(int id)
        {
            var recipe = GetRecipeById(id);
            if (recipe == null)
            {
                return;
            }
            dbContext.Recipes.Remove(recipe);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return dbContext.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return dbContext.Recipes.Find(id);
        }

        public IEnumerable<Recipe> GetRecipes(RecipeCategory? category, string name)
        {
            IQueryable<Recipe> recipes = category == null ? dbContext.Recipes : dbContext.Recipes.Where(r => r.Category == category);
            recipes = recipes.Where(r => r.Name.Contains(name) ||
                                                string.IsNullOrEmpty(name));

            return recipes.OrderBy(r => r.Name);
        }

        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            return dbContext.Recipes.Where(r => r.Name.StartsWith(name) ||
                                                string.IsNullOrEmpty(name))
                                                .OrderBy(r => r.Name);
        }

        public Recipe UpdateRecipe(Recipe updatedRecipe)
        {
            var entity = dbContext.Recipes.Attach(updatedRecipe);
            entity.State = EntityState.Modified;
            return updatedRecipe;
        }
    }
}
