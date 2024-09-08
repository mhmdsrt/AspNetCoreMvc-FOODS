using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters; // Authentication -> Kimlik Doðrýlama

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamamýza View ve Controllerimizi ekler

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login"; // Kimlik Doðrulama baþarýsýz olduðundan yönlendirilcek sayfa(URL)

		/*
        CookieAuthenticationDefaults.AuthenticationScheme parametresi, kimlik doðrulamanýn cookie tabanlý olacaðýný belirtir.
         */
	});

builder.Services.AddMvc(config =>
{     // Build -> oluþturmak.
    var policy = new AuthorizationPolicyBuilder() // AuthorizationPolicyBuilder -> Yetkilendirme Politikasý Oluþturucu
	.RequireAuthenticatedUser() // RequireAuthenticatedUser ->  Kimliði doðrulanmýþ kullanýcý  Gerekli
	.Build();
    config.Filters.Add(new AuthorizeFilter(policy)); // Bu Kimliði Doðrulamýþ filtresini uygumlamanýn tümünü uygula!

	/*
    Bu kod bloðu uygulamadaki tüm controller ve içindeti tüm ActionResultara kimlik doðrulanmadýðýný sürece eriþim kýsýdý getirir.
    Herhangi bir Controller veya Controller içerisindeki ActionResulta kýsýtlama uygulama istemiyorsak "[AllowAnonymous]" ile
    anaonime izin ver yani bilinmeyen izin ver diyerek bu kýsýtlmadan muaf tutuyorsuz.

    Kodun tamamýnda kimliði doðrulanmýþ kullanýcý oluþtur ve bunu MVC'ye filtresini ekle diyoruz.

     */
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	/*
     Uygulamanýn çalýþma ortamýný kontrol eder.Eðer ortam bir geliþtirme ortamý deðilse özel hata sayfalarýný kullanýcýya göstermek yerine
     genel bir hata sayfasý gösterir.
     */
	app.UseExceptionHandler("/Home/Error"); // Eðer bir hata oluþursa "/Home/Error" url'sine yönlendir.
											// Use -> Kullanmak , Exception -> istisna , Handler -> Ýdareci

	app.UseHsts(); // HTTP Strict Transport Security (HSTS) protokolünü etkinleþtirir.
				   // Bu sayede uyglamanýn HTTPS üzerinde çalýþmasýný saðlar ve HTTPS olmayan baðlantýlarý engeller.
}

app.UseHttpsRedirection(); // Gelen Http isteklerini otomatik olarak Https'ye yönlendirir güvenliliði arttýrmak için.

app.UseStaticFiles(); // wwwroot dosyasýndaki CSS,JavaScript,resim gibi dosyalarýn sunulmasýný saðlar.

app.UseRouting(); // Routing gelen URL'leri uygun Controller ve Actionlara yönlendirir.

app.UseAuthorization(); // Authorization -> Yetkilendirme. Kullanýcýnýn belirli bir kaynaða veya iþleme eriþim iznini olup olmadýðýný kontrol eder.


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=GetAllCategory}/{id?}"); // Var sayýlan url'yi belirler.

app.Run(); // Uygulama Çalýþmaya baþlar ve HTTP isteklerini kabul etmeye baþlar.



