using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Core;

namespace Recipes.Data
{
    public class InMemoryRecipeData : IRecipeData
    {
        private readonly List<Recipe> recipes;

        public InMemoryRecipeData()
        {
            recipes = new List<Recipe> {
                new Recipe() { Id = 1, Name = "Chicken Curry", Category = RecipeCategory.Chicken, Review = 5 },
                new Recipe() { Id = 2, Name = "Chocolate Cookies", Category = RecipeCategory.Cookies, Review = 4 },
                new Recipe() { Id = 3, Name = "Shrimp Soup", Category = RecipeCategory.Shrimp, Review = 3 }
            };
        }

        public int Commit()
        {
            // Simulate Committed Successfully
            return 1;
        }

        public void CreateRecipe(Recipe recipe)
        {
            recipe.Id = recipes.Max(r => r.Id) + 1;
            recipes.Add(recipe);
        }

        public void DeleteRecipe(int id)
        {
            var recipe = GetRecipeById(id);
            if (recipe == null)
            {
                return;
            }
            recipes.Remove(recipe);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            var result = recipes.SingleOrDefault(r => r.Id == id);
            return result;
        }

        public IEnumerable<Recipe> GetRecipes(RecipeCategory? category, string name)
        {
            var result = category == null ? recipes : recipes.Where(r => r.Category == category);
            result = from r in result
                   where r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                   orderby r.Name
                   select r;

            return result;
        }

        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            return from r in recipes
            where r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
            orderby r.Name
            select r;
        }

        public Recipe UpdateRecipe(Recipe updatedRecipe)
        {
            var recipe = recipes.SingleOrDefault(r => r.Id == updatedRecipe.Id);

            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Review = updatedRecipe.Review;
                recipe.Category = updatedRecipe.Category;
            }

            return recipe;
        }
    }
}
