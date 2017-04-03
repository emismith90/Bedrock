using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Domain.Data.TypeBuilders
{
    public class TodoType : AuditableTypeConfiguration<TodoEntity, Guid>
    {
        public override void Configure(EntityTypeBuilder<TodoEntity> builder)
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
