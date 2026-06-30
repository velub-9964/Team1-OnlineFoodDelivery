
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RestaurantService.Data;
using RestaurantService.Repositories;
using RestaurantService.Services;

namespace RestaurantService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<RestaurantDbContext>(options=>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService.Services.RestaurantService>();
            
            builder.Services.AddSingleton<IConnectionFactory>(sp=>
                new ConnectionFactory() {HostName = "localhost"}
            );
            builder.Services.AddSingleton<IConnection>(sp=>
                sp.GetRequiredService<RabbitMQ.Client.IConnectionFactory>().CreateConnection()  //error! to be fixed
            );
            builder.Services.AddSingleton<IModel>(sp=>
                sp.GetRequiredService<RabbitMQ.Client.IConnection>().CreateModel()  // error! to be fixed
            );

            builder.Services.AddAuthorization();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
           

            app.Run();
        }
    }
}
