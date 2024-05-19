using AdminApprovalEngine.Infrastructure.Logger;
using API;
using API.ActionFilter;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped(typeof(ValidationModelFilterAttribute<>));
builder.Services.AddScoped<ValidationFilterAttributes>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Host.UseSerilog(Logger.Configure);
builder.Services.ConfigureAPI();
builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(builder.Configuration);

builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(opt => opt.EnrichDiagnosticContext = LogEnricher.EnrichFromRequest);
app.UseRateLimiter();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.Run();


