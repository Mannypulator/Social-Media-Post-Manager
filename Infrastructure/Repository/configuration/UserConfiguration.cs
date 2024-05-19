using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.configuration
{
       public class UserConfiguration : IEntityTypeConfiguration<User>
       {
              public void Configure(EntityTypeBuilder<User> builder)
              {
                     builder.ToTable("Users");

                     builder.HasKey(u => u.Id);

                     builder.Property(u => u.Id)
                            .HasColumnName("UserId")
                            .IsRequired();

                     builder.Property(u => u.UserName)
                            .HasColumnName("UserName")
                            .IsRequired();

                     builder.HasMany(u => u.Following)
                            .WithOne(f => f.Follower)
                            .HasForeignKey(f => f.FollowerId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.HasMany(u => u.Posts)
                            .WithOne(p => p.User)
                            .HasForeignKey(p => p.UserId)
                            .OnDelete(DeleteBehavior.Cascade);

                    
              }
       }
}