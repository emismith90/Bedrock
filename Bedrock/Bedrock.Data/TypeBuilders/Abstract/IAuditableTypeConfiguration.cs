using Bedrock.Data.Models.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Data.TypeBuilders.Abstract
{
    public interface IAuditableTypeConfiguration<TEntity, TEntityKey>
        where TEntity : AuditableEntityBase<TEntityKey>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
