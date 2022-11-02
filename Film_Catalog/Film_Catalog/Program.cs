using Film_Catalog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB:psql
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));
//builder.Services.AddDbContext<>



//builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();-��� ������� ������� �������� ���� ������ �������
//builder.Services.AddSingleton<IApplicationBuilder, ApplicationBuilder>();-������ ������ ���� ������ ������� � ���� � ������ ����� ��� ����������
//builder.Services.AddTransient<IApplicationBuilder, ApplicationBuilder>();-������ �������� �� ������ ��������� � ������� (��������� ������� �������- ��������� ���������)

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

app.UseAuthorization();

app.MapControllers();

app.Run();
