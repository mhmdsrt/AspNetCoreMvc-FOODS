namespace AspNetCoreFood.Models
{
    public class InsertWithImageForFood
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; } // Description -> Tanım
        public double FoodPrice { get; set; }
        public IFormFile FoodImageURL { get; set; } // Dosya türünde ekleyebilmek için
        public int FoodStock { get; set; }

        public int CategoryID { get; set; }
    }
}
