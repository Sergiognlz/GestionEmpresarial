
var builder = WebApplication.CreateBuilder(args);

// Añadir servicios MVC
builder.Services.AddControllersWithViews();

// Registrar servicios desde Container
ListadoPersonasCRUD.DI.Container.RegisterServices(builder.Services);

// Registrar IConfiguration para Conection
builder.Services.AddSingleton(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Rutas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
