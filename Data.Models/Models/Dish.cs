
namespace Data.Models.Models
{
    public class Dish
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int ChefID { get; set; }
    }
}
