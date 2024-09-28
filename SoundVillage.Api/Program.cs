using IdentityServer4.AccessTokenValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Logging;
using SoundVillage.Application.Conta;
using SoundVillage.Application.Conta.Profile;
using SoundVillage.Application.Streaming;
using SoundVillage.Repository;
using SoundVillage.Repository.Repository;
using SoundVillage.Repository.Interfaces;
using SoundVillage.Application.Profile;
using SoundVillage.Application.Streaming.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Description = "Adicione o token JWT para fazer as requisições na APIs",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<SoundVillageContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("SoundVillageConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ArtistaProfile).Assembly);

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = builder.Configuration["IdentityServer:Authority"];
        options.ApiName = "soundvillage-api";
        options.ApiSecret = "SoundVillageSecret";
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("soundvillage-role-user", p =>
    {
        p.RequireClaim("role", "soundvillage-user");
    });
});

IdentityModelEventSource.ShowPII = true;

#region Repositories
builder.Services.AddScoped<ContaStreamingRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<ArtistaRepository>();
builder.Services.AddScoped<CartaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMusicaRepository, MusicaRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
#endregion

#region Services
builder.Services.AddScoped<ContaStreamingService>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<PlanoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<AzureStorageAccount>();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddScoped<AzureServiceBusService>();
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

