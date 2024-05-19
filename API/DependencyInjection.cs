using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using API.Extension;
using Application.validators;
using FluentValidation;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAPI(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {

            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });



            services.AddExceptionHandler<GlobalExceptionalHandler>();

            services.AddRateLimiter(opt =>
            {
                
                opt.AddPolicy("GetPostsPolicy", context =>
                RateLimitPartition.GetFixedWindowLimiter("GetUserPostsAndFolloweeLimiter",
                partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 50,
                    QueueLimit = 0,
                    Window = TimeSpan.FromSeconds(1)
                }));
                opt.AddPolicy("CreatePostPolicy", context =>
                RateLimitPartition.GetFixedWindowLimiter("CreatePostLimiter",
                partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 50,
                    QueueLimit = 0,
                    Window = TimeSpan.FromSeconds(1)
                }));
                // opt.RejectionStatusCode = 429;
                opt.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429;
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        await context.HttpContext.Response.WriteAsync($"Too many requests. Please try again after {retryAfter.TotalSeconds} second(s).", token);
                    }
                    else
                    {
                        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later", token);
                    }
                };
            });

            return services;
        }
    }
}