using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Follow;
using FluentValidation;

namespace Application.validators
{
    public class AddFollowerDtoValidator : AbstractValidator<AddFollowerDto>
    {
        public AddFollowerDtoValidator()
        {
            RuleFor(x => x.FolloweeId)
                .GreaterThan(0);

            RuleFor(x => x.FollowerId)
               .GreaterThan(0);
        }
    }
}