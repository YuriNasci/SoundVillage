using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Application.Admin;
using SoundVillage.Application.Admin.Profile;
using SoundVillage.Application.Conta.Profile;
using SoundVillage.Application.Profile;
using SoundVillage.Application.Streaming;
using SoundVillage.Repository;
using SoundVillage.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SoundVillageAdminContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("SoundVillageConnectionAdmin"));
});

builder.Services.AddDbContext<SoundVillageContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("SoundVillageConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioAdminProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ArtistaProfile).Assembly);

builder.Services.AddScoped<ArtistaRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioAdminRepository>();
builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<PlaylistRepository>();
builder.Services.AddScoped<AlbumRepository>();

builder.Services.AddScoped<UsuarioAdminService>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<AlbumService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
