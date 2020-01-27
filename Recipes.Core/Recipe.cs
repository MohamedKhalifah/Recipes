using System;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Core
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Review { get; set; }

        public RecipeCategory Category { get; set; }
    }
}
