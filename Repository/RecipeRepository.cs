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
    public class RecipeRepository : BaseRepository<Recipe, ApplicationDbContext>
    {
        private ApplicationDbContext _context;
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> getAllByUser(string Uid)
        {
            return await _context.Recipes.Where(r => r.UserId == Uid).Include("RecipeIngredients.Ingredient").ToListAsync();
        }
        public async void setRecipeIngredientOwns(bool owns, int recipeIngredientId)
        {
            var a = _context.RecipeIngredients.Where(r => r.Id == recipeIngredientId).FirstOrDefault();
            if (a !=null)
            {
                a.UserOwns = owns;
            }
            await _context.SaveChangesAsync(); ;
        }

        //Inherits CRUD STUFF        
    }
}
