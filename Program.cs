using Microsoft.EntityFrameworkCore;
using GestaoApi.Models;
using GestaoApi;
using Microsoft.Net.Http.Headers;

var AllowFrontendOrigin = "_allowFrontendOrigin";
var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("DefaultConnection") ??
     throw new InvalidOperationException("Connection string 'DefaultConnection'" +
    " not found.");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowFrontendOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                            .WithMethods("GET", "POST")
                            .WithHeaders(HeaderNames.ContentType);
                      });
});

builder.Services.AddControllers();
// builder.Services.AddOpenApi();
builder.Services.AddDbContext<PedidoContext>(opt => opt.UseNpgsql(conString, o => o.MapEnum<Status>("status")));

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(AllowFrontendOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
