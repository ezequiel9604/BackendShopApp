using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backendShopApp.DataContext;
using backendShopApp.Models;
using backendShopApp.Services;
using backendShopApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding database connection service
// builder.Services.AddDbContext<BackendShopAppDbContext>(opts => opts.UseSqlServer(
//     builder.Configuration.GetConnectionString("BackendShopAppConnectionString")
// ));

builder.Services.AddDbContext<BackendShopAppDbContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString("EFbakendShopAppConnectionString")
));


// adding jwt token authentication service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts => opts.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey=  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:TokenKey").Value)),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    });


builder.Services.AddScoped<IRepositoryClient, RepositoryClient>();
builder.Services.AddScoped<IRepositoryAddress, RepositoryAddress>();
builder.Services.AddScoped<IRepositoryBrand, RepositoryBrand>();
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRepositoryPhone, RepositoryPhone>();
builder.Services.AddScoped<IRepositoryImage, RepositoryImage>();
builder.Services.AddScoped<IRepositoryItem, RepositoryItem>();
builder.Services.AddScoped<IRepositoryPhone, RepositoryPhone>();
builder.Services.AddScoped<IRepositorySubitems, RepositorySubitems>();
builder.Services.AddScoped<IRepositoryAppearance, RepositoryAppearance>();
builder.Services.AddScoped<IRepositoryLanguage, RepositoryLanguage>();
builder.Services.AddScoped<IRepositoryCurrancy, RepositoryCurrancy>();
builder.Services.AddScoped<IRepositoryType, RepositoryType>();
builder.Services.AddScoped<IRepositoryState, RepositoryState>();
builder.Services.AddScoped<IRepositoryComment, RepositoryComment>();

builder.Services.AddScoped<IServiceClient, ServiceClient>();
builder.Services.AddScoped<IServiceItem, ServiceItem>();


builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddCors(c => c.AddPolicy("corsapp", builder => 
{
    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
