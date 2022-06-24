
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using backendShopApp.Microservices.Clienting.ClientInfrastructure.Repositories;
using backendShopApp.Microservices.Clienting.ClientApplication.Services;
using backendShopApp.Microservices.Clienting.ClientInfrastructure.Data;

using backendShopApp.Microservices.Iteming.ItemInfrastructure.Repositories;
using backendShopApp.Microservices.Iteming.ItemApplication.Services;
using backendShopApp.Microservices.Iteming.ItemInfrastructure.Data;

using backendShopApp.Microservices.Commenting.CommentInfrastructure.Data;
using backendShopApp.Microservices.Ordering.OrderInfrastructure.Data;
using backendShopApp.Microservices.Chatting.ChatInfrastructure.Data;
using backendShopApp.Microservices.Administrating.AdministratorInfrastructure.Data;

using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = "DefaultConnectionString";

builder.Services.AddDbContext<ClientContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
));

builder.Services.AddDbContext<ItemContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
));

builder.Services.AddDbContext<CommentContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
));

builder.Services.AddDbContext<OrderContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
));

builder.Services.AddDbContext<ChatContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
));

builder.Services.AddDbContext<AdministratorContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString(connectionString)
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
builder.Services.AddScoped<IRepositoryItem, RepositoryItem>();

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
