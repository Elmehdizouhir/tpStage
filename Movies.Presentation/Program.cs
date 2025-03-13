using Microsoft.EntityFrameworkCore;
using Movies.Application;
using Movies.Infrastructure;
using Movies.Domain;
using Movies.Presentation.Modules;
using Movies.Presentation.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Ajouter les services de l’application
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// 🔹 Configuration de la base de données SQL Server
builder.Services.AddDbContext<MoviesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithOrigins("http://localhost:5175"); // Retirer l'espace supplémentaire
    });
});

// 🔹 Ajouter les services de l’application et de l’infrastructure
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

// 🔹 Activer Swagger uniquement en mode développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Appliquer la politique CORS
app.UseCors("CorsPolicy");  // Applique la politique CORS ici

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

// 🔹 Ajout des endpoints des films
app.AddMoviesEndpoints();

// 🔹 Démarrer l’application
app.Run();
