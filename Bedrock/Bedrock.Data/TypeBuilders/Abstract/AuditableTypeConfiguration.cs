using Bedrock.Data.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Data.TypeBuilders.Abstract
{
    public abstract class AuditableTypeConfiguration<TEntity, TEntityKey> : IAuditableTypeConfiguration<TEntity, TEntityKey>
        where TEntity : AuditableEntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(c => c.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("datetime");

            builder.Property(c => c.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(c => c.ModifiedOn)
               .HasColumnName("ModifiedOn")
               .HasColumnType("datetime");
        }
    }
}
