using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Follow.contract;
using Application.Follow.implementation;
using Application.Post.contract;
using Application.Post.implementation;
using Application.User.contract;
using Application.User.implementation;
using Application.validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DepedencyInjection
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IFollowService, FollowerService>();
            services.AddScoped<IUserService,UserService>();
            services.AddValidatorsFromAssemblyContaining<AddFollowerDtoValidator>();

            return services;
        }
    }
}