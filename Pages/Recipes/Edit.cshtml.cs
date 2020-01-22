using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipes.Core;
using Recipes.Data;

namespace Recipes.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly IRecipeData _recipeData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Recipe Recipe { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public EditModel(IRecipeData recipeData, IHtmlHelper htmlHelper)
        {
            _recipeData = recipeData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {
            Categories = _htmlHelper.GetEnumSelectList<RecipeCategory>();

            if (id == null)
            {
                Recipe = new Recipe();
            }
            else
            {
                Recipe = _recipeData.GetRecipeById(id.Value);
            }

            if (Recipe == null)
            {
                return RedirectToPage("../Shared/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Categories = _htmlHelper.GetEnumSelectList<RecipeCategory>();
                return Page();
            }

            if (Recipe.Id > 0)
            {
                _recipeData.UpdateRecipe(Recipe);
            }
            else
            {
                _recipeData.CreateRecipe(Recipe);
            }

            return RedirectToPage("./Index");
        }
    }
}