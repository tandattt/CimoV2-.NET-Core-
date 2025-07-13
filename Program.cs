using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using Cimo.Models;
using Microsoft.OpenApi.Models;
using DotNetEnv;
using System.Text;
using Cimo.Services.Teacher;
using Cimo.Mapping;
using Cimo.Services.Teacher.Interface;
using System.IdentityModel.Tokens.Jwt;
using Cimo.Filters;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<SuccessResponseFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });

    // Bật xác thực kiểu Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token theo định dạng: Bearer {your JWT token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            //ValidIssuer = Environment.GetEnvironmentVariable("Valid_Issuer"),
            //ValidAudience = Environment.GetEnvironmentVariable("Valid_Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Secret_Key"))),
            RoleClaimType = "authorities",
            NameClaimType = JwtRegisteredClaimNames.Sub

        };
    });


var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 42)))
);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = Environment.GetEnvironmentVariable("URL_REDIS"); // hoặc Redis URL thật
    options.InstanceName = "cimo_";
});

//webhost
//builder.WebHost.UseUrls("https://*:5000");


//mapping
builder.Services.AddAutoMapper(typeof(TeacherMapping).Assembly);

// internface services
builder.Services.Scan(scan => scan
    .FromAssembliesOf(typeof(ILoginTeacherService)) // 👈 dùng FromAssembliesOf
    .AddClasses(c => c.Where(type => type.Name.EndsWith("Service")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
