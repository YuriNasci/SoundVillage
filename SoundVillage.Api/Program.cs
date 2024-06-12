using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using SoundVillage.Application.Conta;
using SoundVillage.Application.Conta.Profile;
using SoundVillage.Application.Streaming;
using SoundVillage.Repository;
using SoundVillage.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SoundVillageContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("SoundVillageConnection"));
});

builder.Services.AddAutoMapper(typeof(ContaStreamingProfile).Assembly);

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://localhost:7285";
        options.ApiName = "soundvillage-api";
        options.ApiSecret = "SoundVillageSecret";
        options.RequireHttpsMetadata = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("soundvillage-role-user", p =>
    {
        p.RequireClaim("role", "soundvillage-user");
    });
});

IdentityModelEventSource.ShowPII = true;

//Repositories
builder.Services.AddScoped<ContaStreamingRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<ArtistaRepository>();
builder.Services.AddScoped<CartaoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<PlaylistRepository>();

//Services
builder.Services.AddScoped<ContaStreamingService>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<PlanoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MusicaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();