using DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// 1️⃣ Agregar MVC
// ---------------------------
builder.Services.AddControllersWithViews();

// ---------------------------
// 2️⃣ Registrar dependencias (DbContext, Repositorios, UseCases)
// ---------------------------
Container.Register(builder.Services, builder.Configuration);

// ---------------------------
// 3️⃣ Construir la app
// ---------------------------
var app = builder.Build();

// ---------------------------
// 4️⃣ Configurar pipeline HTTP
// ---------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ---------------------------
// 5️⃣ Mapear rutas
// ---------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ---------------------------
// 6️⃣ Ejecutar la app
// ---------------------------
app.Run();
