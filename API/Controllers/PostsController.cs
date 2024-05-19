using API.ActionFilter;
using Application.DTOs;
using Application.DTOs.Post;
using Application.Post.contract;
using Domain.Shared.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController(IPostService postService) : BaseController
    {
        [HttpPost]
        [EnableRateLimiting("CreatePostPolicy")]
        [ServiceFilter(typeof(ValidationModelFilterAttribute<PostForCreationDto>))]
        [ServiceFilter(typeof(ValidationFilterAttributes))]
        [ProducesResponseType(typeof(GenericResponse<string>),200)]
        public async Task<IActionResult> AddPostAsync(PostForCreationDto request, CancellationToken cancellationToken)
        {
            var response = await postService.AddPostAsync(request, cancellationToken);
            return StatusCode(GetStatusCode(response.ResponseCode), response);

        }

        [HttpGet("{userId:int}")]
        [EnableRateLimiting("GetPostsPolicy")]
        [ResponseCache(Duration = 10)]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<PostDto>>), 200)]
        public async Task<IActionResult> GetRecentPostsByUserFolloweesAndUserAsync(int userId, [FromQuery] PostParameters postParameters)
        {
            var response = await postService.GetRecentPostsByUserFolloweesAndUserAsync(userId, postParameters);
            return StatusCode(GetStatusCode(response.ResponseCode), response);

        }


        [HttpPost("like-post")]
        [ServiceFilter(typeof(ValidationModelFilterAttribute<PostForLikeDto>))]
        [ServiceFilter(typeof(ValidationFilterAttributes))]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> LikePostAsync(PostForLikeDto request, CancellationToken cancellationToken)
        {
            var response = await postService.LikePostAsync(request, cancellationToken);
            return StatusCode(GetStatusCode(response.ResponseCode), response);
        }



    }
}