using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.configuration
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .HasColumnName("FollowId")
                   .IsRequired();

            builder.Property(f => f.FollowerId)
                   .HasColumnName("FollowerId")
                   .IsRequired();

            builder.Property(f => f.FolloweeId)
                   .HasColumnName("FolloweeId")
                   .IsRequired();

            builder.HasOne(f => f.Follower)
                   .WithMany(u => u.Following)
                   .HasForeignKey(f => f.FollowerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Followee)
                   .WithMany()
                   .HasForeignKey(f => f.FolloweeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}