using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TractionTools.Models;
using TractionTools.Repository;

namespace TractionTools.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class IngredientController : BaseController<Ingredient, IngredientRepository>
    {
        private readonly IngredientRepository _repository;
        private readonly ILogger<IngredientController> _logger;       
        public IngredientController(IngredientRepository repository) : base(repository)
        {
            _repository = repository;            
        }

        [HttpGet("GetIngredientsByRecipe")]
        public async Task<List<RecipeIngredient>> GetIngredientsByRecipe(int recipeId)
        {
            return await _repository.GetIngredientsByRecipeId(recipeId);
        }
        [HttpPost]
        public async Task<IActionResult> SetIngredientAsync(Ingredient ingredient)
        {                   
            return Ok(await _repository.Add(ingredient));
        }
    }
}
