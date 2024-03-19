
namespace Data.Models.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public int DishID { get; set; }
        public int IngredientID { get; set; }
        public decimal Quantity { get; set; }
    }
}
