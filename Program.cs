using Microsoft.EntityFrameworkCore;
using MeuProjetoMvc.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using MeuProjetoMvc.Repositories;

var builder = WebApplication.CreateBuilder(args); // esse já tem no arquivo
// Configura o serviço de Autenticação por Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuario/Login";
        options.AccessDeniedPath = "/Usuario/Login";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
    });

    // Registra os Repositórios do sistema
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// 1. Obtém a string de conexão do appsettings / secrets
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configura o DbContext para usar MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // <-- Adicionado antes do Authorization
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
