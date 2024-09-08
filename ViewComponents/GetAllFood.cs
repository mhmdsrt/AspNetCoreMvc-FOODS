using AspNetCoreFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFood.ViewComponents
{
    public class GetAllFood:ViewComponent
    {
        FoodRepository foodRepository = new FoodRepository();

        public IViewComponentResult Invoke()
        {
            return View(foodRepository.GetAll());
        }
        
    }
}
