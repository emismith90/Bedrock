using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Domain.Data.TypeBuilders.Abstract
{
    public interface IAuditableTypeConfiguration<TEntity, TEntityKey>
        where TEntity : AuditableEntityBase<TEntityKey>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
