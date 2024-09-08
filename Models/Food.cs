using System.ComponentModel.DataAnnotations;

namespace AspNetCoreFood.Models
{
    public class Food
    {
        public int FoodID { get; set; }

      
        public string FoodName { get; set; }
        public string FoodDescription { get; set; } // Description -> Tanım
        public double FoodPrice { get; set; }
        public string FoodImageURL { get; set; }
        public int FoodStock { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
