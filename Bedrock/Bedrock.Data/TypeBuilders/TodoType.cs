using Bedrock.Data.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bedrock.Data.TypeBuilders.Abstract;

namespace Bedrock.Data.TypeBuilders
{
    public class TodoType : AuditableTypeConfiguration<Todo, Guid>
    {
        public override void Configure(EntityTypeBuilder<Todo> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Title)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(255);

            builder.Property(c => c.IsActive)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
