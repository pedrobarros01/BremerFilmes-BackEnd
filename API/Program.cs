/*Este arquivo é o primeiro a ser carregado no projeto da API*/
using Aplicacao.Service;
using Application.IService;
using Application.Mapper;
using Application.Service;
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
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionPostGree"));
});

//Automappers
builder.Services.AddAutoMapper(typeof(GeralMapper));
builder.Services.AddAutoMapper(typeof(ResponseBaseMapper));

//Services e repositorys
builder.Services.AddScoped<IReviewFilmeService, ReviewFilmeService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewFilmeRepository, ReviewFilmeRepository>();
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