using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TareasRestFull.Models;
using TareasRestFull.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API RestFul de Tareas",
        Version = "v1",
        Description = "Desarrollo de Crud de Tareas",
        Contact = new OpenApiContact
        {
            Name = "Lorenzo Bárzaga Meriño",
            Email = "lbarzagam11@gmail.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX"
        }
    });
});

//Se especifica el archivo en el cual se creara la BD de SQLite
builder.Services.AddDbContext<TareasDbContext>(options =>
         options.UseSqlite("Data Source=appTareas.db"));

builder.Services.AddScoped<ITareaService, TareaService>();         

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz (opcional)
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
