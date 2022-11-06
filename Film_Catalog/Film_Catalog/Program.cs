using Film_Catalog;
using Film_Catalog.Services;
using Film_Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB:psql
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироватьс€ издатель при валидации токена
            ValidateIssuer = true,
            // строка, представл€юща€ издател€
            ValidIssuer = JwtConfigurations.Issuer,
            // будет ли валидироватьс€ потребитель токена
            ValidateAudience = true,
            // установка потребител€ токена
            ValidAudience = JwtConfigurations.Audience,
            // будет ли валидироватьс€ врем€ существовани€
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = JwtConfigurations.GetSymmetricSecurityKey(),
            // валидаци€ ключа безопасности
            ValidateIssuerSigningKey = true,

        };
    });



builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();



//builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();-дл€ каждого запроса создаЄтс€ свой объект сервиса
//builder.Services.AddSingleton<IApplicationBuilder, ApplicationBuilder>();-создаЄт только один объект сервиса и живЄт в рамках жизни веб приложени€
//builder.Services.AddTransient<IApplicationBuilder, ApplicationBuilder>();-сервис создаЄтс€ на каждое обращение к сервису (несколько методов сервиса- несколько инстансов)

var app = builder.Build();
/*
using var serviceScope=app.Services.CreateScope();
var context=serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
context?.Database.Migrate();
*/

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
