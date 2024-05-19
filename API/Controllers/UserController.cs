using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ActionFilter;
using Application.DTOs;
using Application.DTOs.User;
using Application.User.contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : BaseController
    {
        [HttpPost]
        [ServiceFilter(typeof(ValidationModelFilterAttribute<UserForCreationDto>))]
        [ServiceFilter(typeof(ValidationFilterAttributes))]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> CreateUserAsync(UserForCreationDto request, CancellationToken cancellationToken)
        {
            var response = await userService.CreateUserAsync(request, cancellationToken);
            return StatusCode(GetStatusCode(response.ResponseCode), response);
        }
    }
}