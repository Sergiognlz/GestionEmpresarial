var builder = WebApplication.CreateBuilder(args);

// MVC + API Controllers
builder.Services.AddControllersWithViews();

// DI
ListadoPersonasCRUD.DI.Container.RegisterServices(builder.Services);

// Configuración
builder.Services.AddSingleton(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 🔹 API Controllers
app.MapControllers();

// 🔹 MVC Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
