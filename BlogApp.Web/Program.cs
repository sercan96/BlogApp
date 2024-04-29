using Data.Abstract;
using Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogAppContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());// Bu ifade bizim SQL ile baðlantýmýzýn tetiklenebilmesi için Middleware'e eklenmiþtir. Bize bir adet nesne üretip controller da kullanmamýzý saðlayacak.

builder.Services.AddScoped<IPostRepository, EfPostRepository>(); // IPostRepository çaðrýldýðýnda EfPostRepository instance'ý al.

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
