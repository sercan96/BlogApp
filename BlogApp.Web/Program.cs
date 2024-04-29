using Data.Abstract;
using Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogAppContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());// Bu ifade bizim SQL ile ba�lant�m�z�n tetiklenebilmesi i�in Middleware'e eklenmi�tir. Bize bir adet nesne �retip controller da kullanmam�z� sa�layacak.

builder.Services.AddScoped<IPostRepository, EfPostRepository>(); // IPostRepository �a�r�ld���nda EfPostRepository instance'� al.

var app = builder.Build();

SeedData.FillTestData(app);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
