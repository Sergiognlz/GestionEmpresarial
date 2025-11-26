using CompositionRoot;

var builder = WebApplication.CreateBuilder(args);

// Inyección de dependencias
// Ahora usamos el repositorio en memoria sin EF

// MVC
builder.Services.AddControllersWithViews();


builder.Services.AddCompositionRoot(builder.Configuration);


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
