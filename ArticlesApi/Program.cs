using ArticlesApi.Context;
using ArticlesApi.Repositories;
using ArticlesApi.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using ArticlesApi.Contracts.Dto;
using ArticlesApi.Services;
using ArticlesApi.Contracts.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>((options) =>
{
    options.UseNpgsql(connectionString: builder.Configuration["ConnectionStrings:Dev"]);
}, contextLifetime: ServiceLifetime.Transient);

builder.Services.AddAutoMapper(typeof(ArticlesProfile));
builder.Services.AddScoped<ICrud<Articles>, ArticlesRepository>();
builder.Services.AddTransient<Service<Articles, ArticlesRequest, ArticlesResponse, ArticlesUpdate>>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
