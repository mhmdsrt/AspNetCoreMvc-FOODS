using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFood.Controllers
{
    [AllowAnonymous]
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFoodByCategory(int id=2) // _SiteLayout sayfasındaki kategoriler tıklandıgında o kategoriye ait ürünleri görüntüleyebilmek için farklı bir view sayfası kullanıyoruz.
        {
            ViewBag.CategoryID = id;
            return View();
        }
    }
}
