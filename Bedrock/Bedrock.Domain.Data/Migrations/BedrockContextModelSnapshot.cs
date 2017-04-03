using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bedrock.Domain.Data.Contexts;

namespace Bedrock.Domain.Data.Migrations
{
    [DbContext(typeof(BedrockContext))]
    partial class BedrockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bedrock.Domain.Data.Models.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnName("ModifiedBy")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });
        }
    }
}
