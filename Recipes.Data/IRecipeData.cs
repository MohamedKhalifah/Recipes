using Recipes.Core;
using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public interface IRecipeData
    {
        public IEnumerable<Recipe> GetAll();
        public IEnumerable<Recipe> GetRecipesByName(string name);
        Recipe GetRecipeById(int id);
    }
}
