using Microsoft.EntityFrameworkCore;
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
    c.UseSqlServer(builder.Configuration.GetConnectionString("SoundVillageConnection"));
});

builder.Services.AddAutoMapper(typeof(ContaStreamingProfile).Assembly);

//Repositories
builder.Services.AddScoped<ContaStreamingRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<ArtistaRepository>();

//Services
builder.Services.AddScoped<ContaStreamingService>();
builder.Services.AddScoped<ArtistaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
