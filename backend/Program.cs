// Program.cs
using Microsoft.EntityFrameworkCore;
using catalogo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:5000", "http://localhost:5001", "http://localhost:4200") // Agrega los orígenes que necesitas
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Cargar la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura el DbContext con la cadena de conexión de SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Habilita los controladores para la API
builder.Services.AddControllers();

// Configura Swagger para documentar la API (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowLocalhost");

// Middleware para Swagger (opcional, para desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
