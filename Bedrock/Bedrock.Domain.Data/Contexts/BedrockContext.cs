using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bedrock.Domain.Data.Models;
using Bedrock.Domain.Data.TypeBuilders;
using Bedrock.Domain.Data.TypeBuilders.Extensions;
using Bedrock.Infrastructure.Configuration.Options;

namespace Bedrock.Domain.Data.Contexts
{
    public class BedrockContext : DbContext
    {
        private readonly ConnectionStringsOptions _connectionStringsOptions;

        public BedrockContext(ConnectionStringsOptions connectionStringsOptions)
        {
            _connectionStringsOptions = connectionStringsOptions;
        }

        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new TodoType());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringsOptions.BedrockConnection);
        }
    }
}
