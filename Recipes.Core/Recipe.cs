using System;

namespace Recipes.Core
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Review { get; set; }
        public RecipeCategory Category { get; set; }
    }
}
