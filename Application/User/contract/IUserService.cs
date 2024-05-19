using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.User;

namespace Application.User.contract
{
    public interface IUserService 
    {
        Task<GenericResponse<string>> CreateUserAsync(UserForCreationDto request, CancellationToken cancellationToken);
    }
}