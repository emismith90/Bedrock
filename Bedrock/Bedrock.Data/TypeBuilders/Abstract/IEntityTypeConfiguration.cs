using Bedrock.Data.Models.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bedrock.Data.TypeBuilders.Abstract
{
    public interface IEntityTypeConfiguration<TEntity, TEntityKey>
        where TEntity : EntityBase<TEntityKey>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
