using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using Microsoft.OpenApi.Models;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        //  Proper Swagger configuration
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Order Service API"
            });
        });

        //  Database
        builder.Services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("OrderDb")
            ));

        var app = builder.Build();

        //  Swagger middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}