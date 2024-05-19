using System;
using Application.DTOs.Post;
using FluentValidation;

namespace Application.validators
{
    public class PostForLikeDtoValidator : AbstractValidator<PostForLikeDto>
    {
        public PostForLikeDtoValidator()
        {
            RuleFor(x => x.PostId).GreaterThan(0);
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}