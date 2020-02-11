using AutoMapper;
using Recipes.Core;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeModel>().ReverseMap();
        }
    }
}
