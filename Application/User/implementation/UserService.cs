using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.User;
using Application.User.contract;
using Domain.interfaces;
using Microsoft.Extensions.Logging;

namespace Application.User.implementation
{
    public class UserService(IRepositoryManager repositoryManager, ILogger<UserService> logger) : IUserService
    {
        public async Task<GenericResponse<string>> CreateUserAsync(UserForCreationDto request, CancellationToken cancellationToken)
        {
            LoggerMessages.LogMethodName(logger, nameof(CreateUserAsync));

            var userExists = await repositoryManager.User.CheckUserNameExistsAsync(request.UserName, false);

            if (userExists)
            {
                return GenericResponse<string>.Failure("44", $"User with {request.UserName} already exists", "");
            }

            var user = new Domain.Entities.User
            {
                UserName = request.UserName
            };

            repositoryManager.User.CreateUser(user);

            await repositoryManager.SaveAsync(cancellationToken);

            return GenericResponse<string>.Success($"Successfully created user : {user.UserName}", "");
        }
    }
}