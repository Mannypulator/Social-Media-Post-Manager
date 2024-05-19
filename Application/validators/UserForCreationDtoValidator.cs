using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.User;
using FluentValidation;

namespace Application.validators
{
    public class UserForCreationDtoValidator : AbstractValidator<UserForCreationDto>
    {
        public UserForCreationDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull();
        }
    }
}