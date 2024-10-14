/*Este arquivo é o primeiro a ser carregado no projeto da API*/
using Application.IService;
using Application.Mapper;
using Application.Service;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.IRepository;
using Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExemploConnection1"));
});

//Automappers
builder.Services.AddAutoMapper(typeof(ExemploMapper));
builder.Services.AddAutoMapper(typeof(ResponseBaseMapper));

//Services e repositorys
builder.Services.AddScoped<IExemploService, ExemploService>();
builder.Services.AddScoped<IExemploRepository, ExemploRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();