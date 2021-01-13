using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractionTools.Data;
using TractionTools.Models;
using TractionTools.Services;

namespace TractionTools.Repository
{
    public class IngredientRepository : BaseRepository<Ingredient, ApplicationDbContext>
    {
        private ApplicationDbContext _context;        
        public IngredientRepository(ApplicationDbContext context) : base(context)        
        {
            _context = context;            
        }
       public async Task<List<RecipeIngredient>> GetIngredientsByRecipeId(int recipeId)
        {
            return await _context.RecipeIngredients.Where(x => x.RecipeId == recipeId).Include(y=>y.Ingredient).ToListAsync();
        }
        //Inherits CRUD STUFF        
    }
}
