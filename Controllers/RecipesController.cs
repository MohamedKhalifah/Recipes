using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Core;
using Recipes.Data;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeData _recipeData;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeData recipeData,
                                 IMapper mapper)
        {
            _recipeData = recipeData;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<RecipeModel>> GetRecipes(RecipeCategory? category, string name)
        {
            var recipes = _recipeData.GetRecipes(category, name);

            return Ok(_mapper.Map<IEnumerable<RecipeModel>>(recipes));
        }

        [HttpGet("{id}", Name ="GetRecipe")]
        public ActionResult<RecipeModel> GetRecipe(int id)
        {
            var recipe = _recipeData.GetRecipeById(id);
            if(recipe == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RecipeModel>(recipe));
        }

        [HttpPost]
        public IActionResult PostRecipe(RecipeModel recipe)
        {
            var recipeEntity = _mapper.Map<Recipe>(recipe);
            _recipeData.CreateRecipe(recipeEntity);
            _recipeData.Commit();
            return CreatedAtRoute("GetRecipe", new { id = recipeEntity.Id }, null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, RecipeModel recipe)
        {
            var recipeEntity = _recipeData.GetRecipeById(id);
            if (recipeEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(recipe, recipeEntity);
            var updatedRecipe = _recipeData.UpdateRecipe(recipeEntity);
            _recipeData.Commit();
            return Ok(_mapper.Map<RecipeModel>(updatedRecipe));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipeEntity = _recipeData.GetRecipeById(id);
            if (recipeEntity == null)
            {
                return NotFound();
            }

            _recipeData.DeleteRecipe(id);
            _recipeData.Commit();
            return Ok();
        }
    }
}
