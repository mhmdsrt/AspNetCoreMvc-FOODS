using AspNetCoreFood.Models;
using AspNetCoreFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AspNetCoreFood.Controllers
{

    public class FoodController : Controller
    {
        Context context = new Context();
        FoodRepository foodRepository = new FoodRepository();


        public IActionResult GetAllFood(string searchWord, int page = 1)
        {
            if (!string.IsNullOrEmpty(searchWord))
            {
                return View(foodRepository.GetAll("Category").Where(x => x.FoodName.Contains(searchWord)).ToPagedList(page, 10));
            }
            return View(foodRepository.GetAll("Category").ToPagedList(page, 10));
        }

        [HttpGet]
        public IActionResult InsertFood()
        {
            List<SelectListItem> selectListCategory = (from c in context.Categories
                                                       where c.Status == true // Yani  güya silinmemiş aktif olan kategorileri çekicez.
                                                       select new SelectListItem
                                                       {
                                                           Value = c.CategoryID.ToString(),
                                                           Text = c.CategoryName

                                                       }).ToList();

            ViewBag.selectListCategory = selectListCategory;

            return View();
        }

        [HttpPost]
        public IActionResult InsertFood(InsertWithImageForFood entity)
        {
            Food food = new Food();
            if (entity.FoodImageURL != null)
            {   // Extension -> Uzantı(.jgp .exe gibi şeyler) , Path -> Yol 
                var extension = Path.GetExtension(entity.FoodImageURL.FileName); // "entity.FoodImageURL.FileName" ifadesi Seçilen dosyanın adını getirir örneğin: araba.jpg. 
                // Path.GetExtension() metodu parametre olarak aldığı dosya adının uzantısını döndürür.

                // Guid.NewGuid() -> sayı ve harflerden oluşan benzersiz kimlik oluşturuyor.
                var newImageName = Guid.NewGuid() + extension;  // Sayı ve harflerden oluşan benzersiz bir kod ile dosya uzantısı birleştirip bir fotoğraf name'i oluşturuyor.
                                                                // Örneğin: "3f2504e0-4f89-11d3-9a0c-0305e82c3301.jpg"

                //Path.Combine() -> verilen dizinleri güvenli bir şekilde birleştirir. Yani "Directory.GetCurrentDirectory()" metodu ile uygulamanın o an çalıştığı dizini alıp sonra "wwwroot/Images/ ifadesini alıp daha sonrada newImageName birleştiriyor.
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/" + newImageName); // Uygulamanın o an çalıştığı dizini döndürür yani örnek: "C:\Projeler\WebApp".   GetCurrentDirectory -> Geçerli dizini al. Location -> Konum.
                
                // Yukarıda tanımladığımız location(konuma) yeni bir dosya oluşturmak için bir akış(stream) oluşturuyoruz.
                var stream = new FileStream(location, FileMode.Create);

                //entity.FoodImageURL -> kullanıcının seçtiği dosya
                entity.FoodImageURL.CopyTo(stream); // kullacının seçtiği dosyayı akışı(stream'i) kopyalar , akışta location dizinine dosyayı oluşturma akışıdır yukarıda oluşturduğumuz gibi.

                food.FoodImageURL = newImageName; // oluşturduğumuz ımage ismini database' kaydedediyoruz.

            }
            food.FoodName = entity.FoodName;
            food.FoodPrice = entity.FoodPrice;
            food.FoodStock = entity.FoodStock;
            food.FoodDescription = entity.FoodDescription;
            food.CategoryID = entity.CategoryID;

            foodRepository.Insert(food);

            return RedirectToAction("GetAllFood");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.Delete(id);
            return RedirectToAction("GetAllFood");
        }

        [HttpGet]
        public IActionResult GetFoodToUpdate(int id)
        {
            var foodToUpdate = foodRepository.GetById(id);

            List<SelectListItem> selectListCategory = (from c in context.Categories
                                                       where c.Status == true
                                                       select new SelectListItem
                                                       {
                                                           Text = c.CategoryName,
                                                           Value = c.CategoryID.ToString()
                                                       }).ToList();

            ViewBag.selectListCategory = selectListCategory;
            return View(foodToUpdate);
        }

        [HttpPost]

        public IActionResult UpdateFood(Food entity)
        {
            foodRepository.Update(entity);
            return RedirectToAction("GetAllFood");
        }
    }
}
