using System;

namespace Application.DTOs.Post
{
    public record PostForCreationDto(string Text, int UserId);
}