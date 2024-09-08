using AspNetCoreFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFood.ViewComponents
{
    public class GetFoodByCategory:ViewComponent
    {
        FoodRepository foodRepository = new FoodRepository();
        public IViewComponentResult Invoke(int id)
        {          
            return View(foodRepository.GetAll().Where(x=>x.CategoryID==id));
        }
    }
}
