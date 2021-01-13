using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractionTools.Models;
using TractionTools.Repository;

namespace TractionTools.Services
{
    public class RecipeService
    {
        private readonly RecipeRepository _recipeRepository;
        public RecipeService(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _recipeRepository.GetAll();
        }
        public async Task<List<Recipe>> GetAllByUserAsync(string Uid)
        {
            return await _recipeRepository.getAllByUser(Uid);
        }
        public async void setRecipeIngredientOwns(bool owns, int recipeIngredientId)
        {
             _recipeRepository.setRecipeIngredientOwns(owns, recipeIngredientId);

        }


    }
}
