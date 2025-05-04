using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleWMS.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimpleWmsDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Controllers (none yet, but we register for later)
builder.Services.AddControllers();

// 3. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WMS API", Version = "v1" });
    // (JWT will be added on Day2)
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS API v1"));
}

app.MapControllers();
app.Run();