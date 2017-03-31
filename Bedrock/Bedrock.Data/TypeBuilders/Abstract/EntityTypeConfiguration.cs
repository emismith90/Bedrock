using Bedrock.Data.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Data.TypeBuilders.Abstract
{
    public abstract class EntityTypeConfiguration<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity, TEntityKey>
        where TEntity : EntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
