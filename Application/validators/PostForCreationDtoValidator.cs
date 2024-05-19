using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Post;
using FluentValidation;

namespace Application.validators
{
    public class PostForCreationDtoValidator : AbstractValidator<PostForCreationDto>
    {
        public PostForCreationDtoValidator()
        {
            RuleFor(x => x.Text)
                .MaximumLength(140)
                .WithMessage("Text must not exceed 140 characters.")
                .NotEmpty()
                .NotNull()
                .WithMessage("Title is required");

            RuleFor(x => x.UserId)
               .NotEmpty()
               .NotNull()
               .WithMessage("UserId is required");
        }
    }
}