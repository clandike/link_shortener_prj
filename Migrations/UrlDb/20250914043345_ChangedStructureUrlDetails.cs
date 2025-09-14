using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Migrations.UrlDb
{
    /// <inheritdoc />
    public partial class ChangedStructureUrlDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_url_details",
                table: "url_details");

            migrationBuilder.DropIndex(
                name: "IX_url_details_url_id",
                table: "url_details");

            migrationBuilder.DropColumn(
                name: "id",
                table: "url_details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_url_details",
                table: "url_details",
                column: "url_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_url_details",
                table: "url_details");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "url_details",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_url_details",
                table: "url_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_url_details_url_id",
                table: "url_details",
                column: "url_id");
        }
    }
}
