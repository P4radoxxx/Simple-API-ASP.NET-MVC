using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using WebAPITest.Repositories;
using WebAPITest.DAL;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using WebAPITest.CustomSwagger;
using WebAPITest.Modeles;
using AutoMapper;
using WebAPITest.DTO;
using WebAPITest.DTOMapper;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json"); // Useless now

string secretKey = builder.Configuration.GetSection("Jwtsettings:SecretKey").Get<string>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();






//Added Services start here

// Repositories
builder.Services.AddScoped<IUserRepository, UserDAL>();
builder.Services.AddScoped<IProjectRepository, ProjectDAL>();
builder.Services.AddScoped<ICounterpartRepository, CounterpartDAL>();


// Authentication token using JWT
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false; 
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwtsettings:SecretKey").Get<string>())),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });


//Auto-Mapper Config
var mapperConfig = new MapperConfiguration(cfg =>
{

    cfg.AddProfile<MappingProfile>();

});

IMapper mapper = mapperConfig.CreateMapper();


//Swagger Config 
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<PasswordHideOperationFilter>();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CrowdFundingTFTIC LAB",
        Version = "v0.1",
        Description = "Much API, very learn,  wow",

        Contact = new OpenApiContact
        {
            Name = "Parad0x Github",
            Url = new Uri("https://github.com/P4radoxxx")

        }

    }); 


    //Swagger custom plugin, not working as expected, but i probably misunderstood or did something wrong...
   // c.DocumentFilter<CustomSwaggerDocumentFilter>();

});





var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
