using Microsoft.EntityFrameworkCore;
using Movies.Application;
using Movies.Infrastructure;
using Movies.Domain;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Ajouter les services de l’application
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Configuration de la base de données SQL Server
builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Ajouter les services de l’application et de l’infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// 🔹 Ajout de CORS pour autoriser le frontend React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 🔹 Activer Swagger uniquement en mode développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Middleware pour la sécurité et les requêtes HTTP
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

// 🔹 Ajout des endpoints des films
app.AddMoviesEndpoints();

// 🔹 Démarrer l’application
app.Run();
