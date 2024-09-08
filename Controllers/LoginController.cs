using AspNetCoreFood.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCoreFood.Controllers
{
    /*
     AllowAnonymous -> Bilinmeyene izin ver.
     Program.cs tarafında " config.Filters.Add(new AuthorizeFilter(policy));" ifadesi ile kimlik doğrulamayı tüm projeye uyguladığımız için
     Login sayfasını bundan muaf tutmak için ve başka muaf tutmak istediğimiz sayfalara "[AllowAnonymous]" uygluyoruz.
                      
	 */

    
	[AllowAnonymous]
	
	public class LoginController : Controller
    {
        Context context = new Context();


		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin entity)
        {
            var log = context.Admins.FirstOrDefault(x => x.AdminUserName == entity.AdminUserName && x.AdminPassword == entity.AdminPassword);
            if (log != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,entity.AdminUserName), // Claim -> Hak/İddia , Claim -> Talep , Bu kod satırında kullanıcın kimlik bilgilerini temsil eden bir liste oluşturuyoruz.
                   

                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");// Burada bir tane kimlik oluşturup oluşturduğumuz kimlik bilgilerini ve kimlik doğrulama türünü parametre olarak belitriyoruz.
																		 // Yani "Login" ile kimlik doğrulama türünü belirtiyoruz ve bunun bir oturum açma için yapacağımızı belirtiyoruz.
				
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
				// Parametre olarak aldığı "claimsPrincipal" kimlik bilgilerini doğrulanmış olarak işaretler ve tarayıcı bunu cookie(çerez) olarak kaydeder.
				// Böylece sitenin diğer kimlik doğrulama gerektiren sayfalarına tekrar giriş yapmasına gerek kalmadan tarayıcıda bulunan cookie(çerez) sayesinde dolaşabiliyor.
				return RedirectToAction("GetAllCategory","Category");
            }
            else
            {
                
                return View("Login");
            }

        }

        [HttpGet]
        public async Task<IActionResult> LogOut() // LogOut -> Oturumu Kapat , SignOut -> Oturumu Kapat
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            /*
             HttpContext -> Http isteğiyle ilgili tüm bilgilere erişmemizi sağlar.
            SignOutAsync() metodu -> Kullancının tarayıcısındaki saklanan kimlik doğrulama
            cookies(çerezlerini) siler. ve kullancının oturumunu sonladırır.
             
            CookieAuthenticationDefaults.AuthenticationScheme -> hangi kimlik doğrulama şemasını kullanacağını belirtir.
            Bunuda biz program.cs de oluşturmuştuk
            */
            return RedirectToAction("Login", "Login");
        }


    }


}
