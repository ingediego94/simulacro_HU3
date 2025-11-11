using catalogoProductos.Application.Auth;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Application.Services;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Extensions;
using catalogoProductos.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// ---------------------------------------------------------
// DEPENDENCY INJECTIONS:

// BD:
builder.Services.AddInfrastructure(builder.Configuration);

// Adding services to the container:
builder.Services.AddControllers();

// PasswordHasher:
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRegisterPersonService, RegisterPersonService>();

// Admin
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

// Client
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

// Seller
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();

// Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Login service
builder.Services.AddScoped<LoginService>();



// JWT
var key = builder.Configuration["Jwt:Key"];
var issuer =  builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key))
        };
    });



// ---------------------------------------------------------

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//***
app.UseAuthorization();
app.MapControllers();


app.Run();

