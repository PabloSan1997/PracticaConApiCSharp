using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Services;
using WebApplication1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceImage, ImagenesServicios>();
builder.Services.AddSqlServer<ContextImagenes>(builder.Configuration.GetConnectionString("cnTareas"), builder =>
{
builder.EnableRetryOnFailure();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.AllowAnyHeader();
    p.AllowAnyMethod();
});

app.UseAuthorization();

app.UseHeaderImage();

app.MapControllers();

app.Run();
