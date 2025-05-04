using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleWMS.Application.Abstractions;
using SimpleWMS.Infrastructure.Auth;
using SimpleWMS.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimpleWmsDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Controllers (none yet, but we register for later)
builder.Services.AddControllers();

// 3. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", opt =>
    {
        var key = builder.Configuration["Jwt:Key"]!;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "WMS API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new()
    {
        {
            new() { Reference = new() { Id = "Bearer", Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme } },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WMS API v1"));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();