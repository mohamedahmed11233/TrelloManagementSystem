﻿using AutoMapper;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Reflection;
using TrelloManagementSystem.Common.Database.Context;
using TrelloManagementSystem.Common.ErrorHandling;
using TrelloManagementSystem.Common.Middlewares;
using TrelloManagementSystem.Common.RequestStructure;
using TrelloManagementSystem.Common.Response;
using TrelloManagementSystem.Features.Common;
using TrelloManagementSystem.Features.Tasks.UpdateExpiredTasks;

namespace TrelloManagementSystem.Common.Helper.ExtensionMethod
{
    public static class AddExtensionMethods
    {
        public static IServiceCollection AddDependencyInjectionMethods(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddScoped<GlobalTranactionMiddleware>();
            Services.AddScoped<ExceptionMiddleware>();
            Services.AddScoped(typeof(GenericRepository<>));
            Services.AddScoped<BaseRequestParameters>();
            Services.AddScoped(typeof(BaseEndpointParameters<>));

           

            Services.AddDbContext<TrelloContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            Services.AddAutoMapper(typeof(Program));
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = mapperConfig.CreateMapper();
            Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    typeof(Program).Assembly
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
            Services.AddHangfire(opt =>
            {
                opt.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
                opt.UseRecommendedSerializerSettings();
                opt.UseSimpleAssemblyNameTypeSerializer();
                opt.UseRecommendedSerializerSettings();
            });
            Services.AddHangfireServer();

            // Fix: Add Hangfire Dashboard as middleware in the application pipeline instead of IServiceCollection
            return Services;
        }
    }

}

