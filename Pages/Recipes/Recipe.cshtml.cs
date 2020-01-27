using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes.Core;
using Recipes.Data;

namespace Recipes.Pages.Recipes
{
    public class RecipeModel : PageModel
    {
        public Recipe Recipe { get; set; }
        private readonly IRecipeData _recipeData;

        public RecipeModel(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }

        public IActionResult OnGet(int id)
        {
            Recipe = _recipeData.GetRecipeById(id);
            if (Recipe == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }
            return Page();
        }
    }
}
