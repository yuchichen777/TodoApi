
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TodoApi.Authentication;
using TodoApi.Interceptor;
using TodoApi.Models;
using TodoApi.Repository;
using TodoApi.Services;

namespace TodoApi
{
     public class Program
     {
          public static void Main(string[] args)
          {
               var builder = WebApplication.CreateBuilder(args);

               // Add services to the container.

               builder.Services.AddControllers();
               // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
               builder.Services.AddEndpointsApiExplorer();
               builder.Services.AddSwaggerGen();

               builder.Services.AddDbContext<DbContext, TodoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext")));

               builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
               builder.Services.AddTransient<ITodoService, TodoService>();

               builder.Services.ConfigureDynamicProxy(config =>
               {
                    config.Interceptors.AddTyped<ServiceInterceptor>(Predicates.ForService("*Service"));
               });

               builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

               var app = builder.Build();

               // Configure the HTTP request pipeline.
               if (app.Environment.IsDevelopment())
               {
                    app.UseSwagger();
                    app.UseSwaggerUI();
               }

               app.UseHttpsRedirection();

               app.UseAuthorization();

               app.UseMiddleware<ApiKeyMiddleware>();

               app.MapControllers();

               app.Run();
          }
     }
}
