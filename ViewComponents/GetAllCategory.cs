using AspNetCoreFood.Repositories;
using AspNetCoreFood.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace AspNetCoreFood.ViewComponents
{
    /*
     Yani ViewComponents dediğimiz yapı veri tabanı işlemlerini yaptığımız bir class oluşturmakla başlayıp 
     sonrasında View/Shread tarafında gene bu Class isminde bir view oluşturarak, daha sonrasında 
     bu oluştuduğumuz view'i başka view'ler içerisinde kullanbilmemizi sağlıyor
     */
    public class GetAllCategory : ViewComponent //     

    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IViewComponentResult Invoke() // _SiteLayout sayfasında "@await Component.InvokeAsync("GetAllCategory")" ile çağırıldığın zaman Shared/Components/GetAllCategory/Default.cshtml sayfasını döndür.
        // Invoke -> Çağırmak.   Component -> Bileşen
        {
            return View(categoryRepository.GetAll());
        }
    }
}



