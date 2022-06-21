using Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(option =>
{
    option.AddPolicy("EnableCORS", builders =>
    {
        builders.AllowAnyOrigin();
        builders.AllowAnyMethod();
        builders.AllowAnyMethod();
    });
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

CRUD.Configuration.Mapping.ConfigureAutoMapper.Configure(builder.Services);
CRUD.Configuration.Services.ServiceConfiguration.Configuration(builder.Services, builder.Configuration, connection);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
