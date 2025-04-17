using Web_Cart.Models.Momo;
using Web_Cart.Services.Momo;

var builder = WebApplication.CreateBuilder(args);
//Momo API Payment
builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();

// Thêm d?ch v? cho MVC
builder.Services.AddControllersWithViews();

// C?u hình Session
builder.Services.AddDistributedMemoryCache(); // B?t bu?c ?? s? d?ng Session
builder.Services.AddSession();

var app = builder.Build();

// Kích ho?t s? d?ng file t?nh (cho wwwroot)
app.UseStaticFiles();

// Kích ho?t Session
app.UseSession();

// C?u hình x? lý l?i khi không ? ch? ?? Development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// C?u hình middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// C?u hình route m?c ??nh
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
