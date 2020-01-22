﻿using System;
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

        public IEnumerable<Recipe> GetAll()
        {
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            var result = recipes.SingleOrDefault(r => r.Id == id);
            return result;
        }

        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            var result = from r in recipes
                   where r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                   orderby r.Name
                   select r;

            return result;
        }
    }
}
