using Recipes.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 5)]
        public int Review { get; set; }

        public RecipeCategory Category { get; set; }
    }
}
