using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string Unit { get; set; }
        public int SupplierID { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
