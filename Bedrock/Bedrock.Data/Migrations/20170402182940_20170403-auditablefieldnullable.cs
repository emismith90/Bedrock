using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bedrock.Data.Migrations
{
    public partial class _20170403auditablefieldnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Todos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifiedBy",
                table: "Todos",
                type: "UNIQUEIDENTIFIER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Todos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Todos",
                type: "UNIQUEIDENTIFIER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Todos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifiedBy",
                table: "Todos",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Todos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Todos",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER",
                oldNullable: true);
        }
    }
}
