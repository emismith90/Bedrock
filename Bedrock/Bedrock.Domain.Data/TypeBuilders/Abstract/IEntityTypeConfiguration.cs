using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bedrock.Domain.Data.Models;

namespace Bedrock.Domain.Data.TypeBuilders.Abstract
{
    public interface IEntityTypeConfiguration<TEntity, TEntityKey>
        where TEntity : EntityBase<TEntityKey>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
