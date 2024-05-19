using API.ActionFilter;
using Application.DTOs;
using Application.DTOs.Follow;
using Application.Follow.contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class FollowController(IFollowService followService):BaseController
    {
        [HttpPost]
        [ServiceFilter(typeof(ValidationModelFilterAttribute<AddFollowerDto>))]
        [ServiceFilter(typeof(ValidationFilterAttributes))]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> AddFollowerAsync(AddFollowerDto request, CancellationToken cancellationToken)
        {
            var response = await followService.AddFollowerAsync(request, cancellationToken);
            return StatusCode(GetStatusCode(response.ResponseCode), response);
        }

        [HttpGet("{userId:int}")]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<FollowDto>>), 200)]
        public async Task<IActionResult> GetUserFollowersAsync(int userId)
        {
            var response = await followService.GetUserFollowersAsync(userId);
            return StatusCode(GetStatusCode(response.ResponseCode), response);
        }
    }

    
}