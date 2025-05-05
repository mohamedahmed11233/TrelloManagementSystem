
using Microsoft.EntityFrameworkCore;
using TrelloManagementSystem.Common.Database.Context;
using TrelloManagementSystem.Common.Helper.ExtensionMethod;
using TrelloManagementSystem.Common.Middlewares;

namespace TrelloManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<TrelloContext>(opthion =>
            {
                opthion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDependencyInjectionMethods(builder.Configuration);
            builder.Logging.AddSerilogLogger(builder.Configuration, builder);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<GlobalTranactionMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
