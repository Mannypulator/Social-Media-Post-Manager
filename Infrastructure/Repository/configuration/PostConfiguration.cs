using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.configuration
{
       public class PostConfiguration : IEntityTypeConfiguration<Post>
       {
              public void Configure(EntityTypeBuilder<Post> builder)
              {
                     builder.ToTable("Posts");

                     builder.HasKey(p => p.Id);

                     builder.Property(p => p.Id)
                            .HasColumnName("PostId")
                            .IsRequired();

                     builder.Property(p => p.UserId)
                            .HasColumnName("UserId")
                            .IsRequired();

                     builder.Property(p => p.Text)
                            .HasColumnName("Text")
                            .HasMaxLength(140)
                            .IsRequired();


                     builder.Property(p => p.DateCreated)
                            .HasColumnName("DateCreated")
                            .IsRequired();

                     builder.Property(p => p.DateUpdated)
                            .HasColumnName("DateUpdated")
                            .IsRequired();

                     builder.HasOne(p => p.User)
                            .WithMany(u => u.Posts)
                            .HasForeignKey(p => p.UserId)
                            .OnDelete(DeleteBehavior.Cascade);

              }
       }
}