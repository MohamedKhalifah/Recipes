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
    public class IndexModel : PageModel
    {
        private readonly IRecipeData _recipeData;
        public IEnumerable<Recipe> Recipes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Recipes = _recipeData.GetAll();
                return;
            }
            Recipes = _recipeData.GetRecipesByName(SearchTerm);
        }
    }
}
