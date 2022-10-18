using Microsoft.EntityFrameworkCore;
using MusicLibDbCtx;
using MusicLibDbCtx.Model;
using MusicLibFramework.Repositories;
using MusicLibFramework.Repositories.Interfaces;
using MusicLibFramework.Services;
using MusicLibFramework.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using System;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);
string dbConnStr = string.Empty;

if (builder.Environment.IsProduction())
{
    // get connection string based on the way secrets in KeyVault are accessed
}
else
{
    // using secrets manager during development
    dbConnStr = builder.Configuration["ConnectionStrings:MusicLibDb"];
}

// Add database context to container; 
// Note: for non-cloud based dbs, this is separate container that needs to be running alongside this container
// To persist data, database container should use database attached via volume or bind.
builder.Services.AddDbContext<MusicLibDbContext>(options => options.UseSqlServer(dbConnStr));
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<MusicLibDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAlbumService, AlbumService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var dbCtx = services.GetRequiredService<MusicLibDbContext>();
    if (dbCtx.Database.IsSqlServer())
    {
        dbCtx.Database.Migrate();
    }
}
catch (Exception exc)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(exc, "An error occured migrating MusicLib database");
    throw;
}

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
