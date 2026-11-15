using Gestion_de_Citas.Application.Contract;
using Gestion_de_Citas.Application.Services;
using Gestion_de_Citas.Infraestructure.Context;
using Gestion_de_Citas.Infraestructure.Repositories;
using Gestion_de_Citas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); builder.Services.AddOpenApi(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Contexto nuevo (capa de Infraestructura)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Contexto viejo (temporal, para los controllers que aún no usan servicios)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios y servicios
builder.Services.AddScoped<IEspecialIdadRepository, EspecialIdadRepository>();
builder.Services.AddScoped<IEspecialIdadService, EspecialIdadService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization(); app.MapControllers();
app.Run();