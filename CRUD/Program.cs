﻿using CRUD.ReportService;
using Database.Database;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("abcd")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//builder.Services.AddScoped<IReportServices, ReportService>();

builder.Services.AddCors(option =>
{
    option.AddPolicy("EnableCORS", builders =>
    {
        builders.AllowAnyOrigin();
        builders.AllowAnyMethod();
        builders.AllowAnyMethod();
    });
});

builder.Services.AddMvc(m=> m.EnableEndpointRouting = false);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")));

CRUD.Configuration.Mapping.ConfigureAutoMapper.Configure(builder.Services);
CRUD.Configuration.Services.ServiceConfiguration.Configuration(builder.Services, builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("EnableCORS");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
