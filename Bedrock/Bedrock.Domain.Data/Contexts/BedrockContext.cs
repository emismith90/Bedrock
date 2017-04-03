using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bedrock.Domain.Data.Models;
using Bedrock.Domain.Data.TypeBuilders;
using Bedrock.Domain.Data.TypeBuilders.Extensions;

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
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("BedrockConnection"));
        }
    }
}
