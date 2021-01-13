using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractionTools.Models
{
    public class RecipeIngredient : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }            
        public bool UserOwns { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}
