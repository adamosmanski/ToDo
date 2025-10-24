using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todo_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo_items", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "todo_items",
                columns: new[] { "id", "created_at", "description", "title" },
                values: new object[] { 1, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4622), "Opis 1", "Zadanie 1" });

            migrationBuilder.InsertData(
                table: "todo_items",
                columns: new[] { "id", "created_at", "description", "is_completed", "title" },
                values: new object[] { 2, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4654), "Opis 2", true, "Zadanie 2" });

            migrationBuilder.InsertData(
                table: "todo_items",
                columns: new[] { "id", "created_at", "description", "title" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4655), "Opis 3", "Zadanie 3" },
                    { 4, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4656), "Opis 4", "Zadanie 4" }
                });

            migrationBuilder.InsertData(
                table: "todo_items",
                columns: new[] { "id", "created_at", "description", "is_completed", "title" },
                values: new object[] { 5, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4657), "Opis 5", true, "Zadanie 5" });

            migrationBuilder.InsertData(
                table: "todo_items",
                columns: new[] { "id", "created_at", "description", "title" },
                values: new object[] { 6, new DateTime(2025, 10, 24, 10, 46, 34, 15, DateTimeKind.Utc).AddTicks(4658), "Opis 6", "Zadanie 6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo_items");
        }
    }
}
