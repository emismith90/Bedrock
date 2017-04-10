using Microsoft.EntityFrameworkCore;
using Bedrock.Domain.Data.Models;
using Bedrock.Domain.Data.TypeBuilders;
using Bedrock.Domain.Data.TypeBuilders.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bedrock.Domain.Data.Contexts
{
    public class BedrockContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new TodoType());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseMySql(config.GetConnectionString("BedrockConnection"));
        }
    }
}
