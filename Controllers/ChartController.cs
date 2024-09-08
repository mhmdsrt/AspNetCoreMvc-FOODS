using AspNetCoreFood.Models;
using AspNetCoreFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFood.Controllers
{
    /*
        Yakınlaştırmak için (Zoom In):

        Ctrl + Shift + . (nokta)
        Uzaklaştırmak için (Zoom Out):
    
        Ctrl + Shift + , (virgül)
    */
    
    public class ChartController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();

  
		public IActionResult GetPieChartProductStock()
        {
            return View();
        }

        public IActionResult GetColumnChartProductPrice()
        {
            return View();
        }


        public List<Food> GetListProduct()
        {
            return foodRepository.GetAll();
            
        }
		
		public IActionResult VisualizeProductResult()
        {
            return Json(GetListProduct());
        }

        public IActionResult Statistics()
        {
            ViewBag.v1 = context.Foods.Count();
            ViewBag.v2 = context.Categories.Count();          
            ViewBag.v3 = context.Foods.OrderByDescending(x => x.FoodPrice).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.v4 = context.Foods.OrderBy(x => x.FoodPrice).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.v5 = context.Foods.OrderByDescending(x => x.FoodPrice).Select(y => y.FoodPrice).FirstOrDefault();
            ViewBag.v6 = context.Foods.OrderBy(x => x.FoodPrice).Select(y => y.FoodPrice).FirstOrDefault();
            ViewBag.v7 = context.Foods.Sum(x=>x.FoodStock);
            ViewBag.v8 = context.Foods.OrderByDescending(y=>y.FoodStock).Select(x=>x.FoodStock).FirstOrDefault();
            ViewBag.v9 = context.Foods.OrderBy(y=>y.FoodStock).Select(x=>x.FoodStock).FirstOrDefault();
            ViewBag.v10 = context.Foods.Average(x => x.FoodStock).ToString("0.000");
            ViewBag.v11 = context.Foods.Where(x => x.Category.CategoryName == "Sebzeler").Count();
            ViewBag.v12 = context.Foods.Where(x => x.Category.CategoryName == "Meyveler").Count();
            ViewBag.v13 = context.Foods.Where(x => x.Category.CategoryName == "Bakliyatlar").Count();
            ViewBag.v14 = context.Foods.Where(x => x.Category.CategoryName == "Sebzeler").OrderByDescending(y=>y.FoodPrice).Select(z=>z.FoodName).FirstOrDefault();
            ViewBag.v15 = context.Foods.Where(x => x.Category.CategoryName == "Sebzeler").OrderByDescending(y=>y.FoodPrice).Select(z=>z.FoodPrice).FirstOrDefault();
            ViewBag.v16 = context.Foods.Where(x => x.Category.CategoryName == "Meyveler").OrderByDescending(y => y.FoodPrice).Select(z => z.FoodName).FirstOrDefault();
            ViewBag.v17 = context.Foods.Where(x => x.Category.CategoryName == "Meyveler").OrderByDescending(y => y.FoodPrice).Select(z => z.FoodPrice).FirstOrDefault();
            ViewBag.v18 = context.Foods.Where(x => x.Category.CategoryName == "Bakliyatlar").OrderByDescending(y => y.FoodPrice).Select(z => z.FoodName).FirstOrDefault();
            ViewBag.v19 = context.Foods.Where(x => x.Category.CategoryName == "Bakliyatlar").OrderByDescending(y => y.FoodPrice).Select(z => z.FoodPrice).FirstOrDefault();
            ViewBag.v20 = context.Foods.Where(x => x.Category.CategoryName == "Sebzeler").OrderBy(y => y.FoodPrice).Select(z => z.FoodName).FirstOrDefault();
            ViewBag.v21 = context.Foods.Where(x => x.Category.CategoryName == "Sebzeler").OrderBy(y => y.FoodPrice).Select(z => z.FoodPrice).FirstOrDefault();
            ViewBag.v22 = context.Foods.Where(x => x.Category.CategoryName == "Meyveler").OrderBy(y => y.FoodPrice).Select(z => z.FoodName).FirstOrDefault();
            ViewBag.v23 = context.Foods.Where(x => x.Category.CategoryName == "Meyveler").OrderBy(y => y.FoodPrice).Select(z => z.FoodPrice).FirstOrDefault();
            return View();
        }
    }
}
