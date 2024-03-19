using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
