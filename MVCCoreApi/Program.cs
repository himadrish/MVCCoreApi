using Microsoft.EntityFrameworkCore;
using MVCCoreApi.Models;
using MVCCoreApiMovie.Models;
using MVCCoreApiMovie.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MovieDBSettings>(
    builder.Configuration.GetSection("MovieStoreDatabase"));

//Added Movie Service
builder.Services.AddSingleton<MovieService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
