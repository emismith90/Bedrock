using Bedrock.Data.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Bedrock.Data.TypeBuilders.Abstract;

namespace Bedrock.Data.TypeBuilders.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity, TKey>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity, TKey> configuration) 
            where TEntity : EntityBase<TKey>
        {
            configuration.Configure(modelBuilder.Entity<TEntity>());
        }

        public static void AddConfiguration<TEntity, TKey>(this ModelBuilder modelBuilder, AuditableTypeConfiguration<TEntity, TKey> configuration)
           where TEntity : AuditableEntityBase<TKey>
        {
            configuration.Configure(modelBuilder.Entity<TEntity>());
        }
    }
}
