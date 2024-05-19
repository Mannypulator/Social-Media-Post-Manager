using System;

namespace Application.DTOs.Post
{
    public record PostDto(
        int Id, 
        int UserId, 
        string Text, 
        int Likes, 
        string DateCreated, 
        string DateUpdated
    );
}