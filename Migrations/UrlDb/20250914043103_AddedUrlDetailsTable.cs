using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Migrations.UrlDb
{
    /// <inheritdoc />
    public partial class AddedUrlDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "urls");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "urls");

            migrationBuilder.CreateTable(
                name: "url_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    click_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_url_details_urls_url_id",
                        column: x => x.url_id,
                        principalTable: "urls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_url_details_url_id",
                table: "url_details",
                column: "url_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "url_details");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "urls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "urls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
