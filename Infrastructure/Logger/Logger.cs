using Destructurama;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace AdminApprovalEngine.Infrastructure.Logger;

public static class Logger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
        (context, configuration) =>
        {
            ITextFormatter jsonFormatter = new Serilog.Formatting.Json.JsonFormatter(renderMessage: true);

            configuration
                .Destructure.UsingAttributes()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .MinimumLevel.ControlledBy(new LoggingLevelSwitch())
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MMM-yyyy:HH:mm:ss} {Level:u3}-API==>SocialMediaPostManager] {Message}{NewLine}{Exception}")
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                .ReadFrom.Configuration(context.Configuration);
        };
}