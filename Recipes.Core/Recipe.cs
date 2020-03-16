﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Core
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Review { get; set; }

        public RecipeCategory Category { get; set; }
    }
}
