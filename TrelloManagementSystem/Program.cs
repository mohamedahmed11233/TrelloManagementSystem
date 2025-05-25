using Hangfire;
using MediatR;
using Serilog;
using TrelloManagementSystem.Common.Helper.ExtensionMethod;
using TrelloManagementSystem.Common.Middlewares;
using TrelloManagementSystem.Features.CommonFeatures.BackgroundJobs.TasksJop;
using TrelloManagementSystem.Features.Tasks.UpdateExpiredTasks;
namespace TrelloManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDependencyInjectionMethods(builder.Configuration);
            builder.Logging.ClearProviders(); 
            builder.Logging.AddSerilogLogger(builder.Configuration, builder);
            var app = builder.Build();

       
            var scope = app.Services.CreateScope();
            var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

            recurringJobManager.AddOrUpdate<UpdateExpiredTasksJob>(
                "UpdateExpiredTasks",
                job => job.Run(),  // method to call
                Cron.Minutely       // every minute
            );

            try
            {
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseSerilogRequestLogging();
                app.UseMiddleware<LoggingMiddleware>();
                app.UseMiddleware<GlobalTranactionMiddleware>();
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseHangfireDashboard("/hangfire");

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception)
            { 

                builder.Logging.AddSerilogLogger(builder.Configuration,builder);
            }
        }
    }
}
