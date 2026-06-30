using CartService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();


builder.Services.AddDbContext<CartDbContext>(options => 
options.UseSqlServer(
    builder.Configuration.GetConnectionString("CartDb")
    ));
var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


 // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
