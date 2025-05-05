using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Reflection;
using TrelloManagementSystem.Common.Database.Context;
using TrelloManagementSystem.Common.ErrorHandling;
using TrelloManagementSystem.Common.Middlewares;

namespace TrelloManagementSystem.Common.Helper.ExtensionMethod
{
    public static class AddExtensionMethods
    {

        public static IServiceCollection AddDependencyInjectionMethods(this IServiceCollection Services, IConfiguration configuration)
        {

            Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
          Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddScoped<GlobalTranactionMiddleware>();
            Services.AddScoped<ExceptionMiddleware>();
            Services.AddDbContext<TrelloContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    typeof(Program).Assembly,
                    Assembly.Load("Application")
                )
            );

            #region ApiValidationErrorr
            Services.Configure<ApiBehaviorOptions>(opthion =>
            {
                opthion.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(o => o.Value?.Errors.Count() > 0)
                                                         .SelectMany(o => o.Value.Errors)
                                                         .Select(e => e.ErrorMessage)
                                                         .ToList();
                    var response = new ApiValidationError()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });
            #endregion

            Services.AddSingleton<IConnection>(sp =>
            {
                var factory = new ConnectionFactory { HostName = "localhost" }; // Adjust settings as needed
                return factory.CreateConnectionAsync().GetAwaiter().GetResult();
            });

            Services.AddSingleton<IChannel>(sp =>
            {
                var connection = sp.GetRequiredService<IConnection>();
                return connection.CreateChannelAsync().GetAwaiter().GetResult();
            });
            Services.AddHttpContextAccessor();

            Services.AddControllersWithViews();

            return Services;
        }
    }

}

