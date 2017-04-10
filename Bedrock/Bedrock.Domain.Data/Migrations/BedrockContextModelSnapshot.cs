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
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Bedrock.Domain.Data.Models.TodoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnName("ModifiedBy");

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
