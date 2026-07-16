using Microsoft.EntityFrameworkCore;
using GestaoApi.Models;
using GestaoApi;

var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("DefaultConnection") ??
     throw new InvalidOperationException("Connection string 'DefaultConnection'" +
    " not found.");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PedidoContext>(opt => opt.UseNpgsql(conString, o => o.MapEnum<Status>("status")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
