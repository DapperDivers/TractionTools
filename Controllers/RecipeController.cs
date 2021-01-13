using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TractionTools.Data;
using TractionTools.Models;
using TractionTools.Repository;
using TractionTools.Repository.Interfaces;
using TractionTools.Services;

namespace TractionTools.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class RecipeController : BaseController<Recipe, RecipeRepository>
    {
        private readonly RecipeRepository _repository;
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipeService _recipeService;        
       public RecipeController(RecipeRepository repository) : base(repository)
        {
            _repository = repository;
            _recipeService = new RecipeService(repository);            
        }
        [HttpGet("GetUserRecipes")]
        public virtual async Task<List<Recipe>> GetRecipesAsync()
        {                        
           var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return await _recipeService.GetAllByUserAsync(userId);
        }

        [HttpPost("SetUserRecipe")]
        public virtual async Task<IActionResult> SetRecipeAsync(Recipe recipe)
        {
            recipe.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return Ok(await _repository.Add(recipe));
        }
        [HttpPost("setOwns")]
        public virtual async Task<IActionResult> SetRecipeIngredient([FromBody] recipeIngredientDto data)
        {                       

            _recipeService.setRecipeIngredientOwns(data.owns, data.recipeIngredientId);
          return Ok();            
        }
        public class recipeIngredientDto
        {
            [JsonPropertyName("owns")]
            public bool owns { get; set; }

            [JsonPropertyName("recipeIngredientId")]
            public int recipeIngredientId { get; set; }
          
        }

    }
}
