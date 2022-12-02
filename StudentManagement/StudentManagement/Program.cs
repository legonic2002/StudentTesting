using Microsoft.EntityFrameworkCore;
using ShoppingWebAPI.EFcore;
using FluentValidation;
using FluentValidation.AspNetCore;
using ShoppingWebAPI.Model;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<EF_DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EF_Postgres_DB"))
    );


builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
