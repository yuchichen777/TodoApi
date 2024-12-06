
using Microsoft.EntityFrameworkCore;
using TodoApi.Authentication;
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

               builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
               builder.Services.AddScoped<ITodoService, TodoService>();

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
