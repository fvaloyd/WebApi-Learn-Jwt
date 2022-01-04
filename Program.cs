using LearningJWT.Repository;
using LearningJWT.Repository.Interfaces;
using LearningJWT.Mappers;
using Microsoft.EntityFrameworkCore;
using LearningJWT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LearningJWT.Services;
using LearningJWT.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependencys
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

// ApplicationDbContext
builder.Services.AddDbContext<ApplicationContext>(opt => {
    opt.UseLazyLoadingProxies();
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// jwt config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
    opt.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Token"]) ),
        ValidateIssuer = false,
        ValidateAudience = false
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();

// add authentication
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
