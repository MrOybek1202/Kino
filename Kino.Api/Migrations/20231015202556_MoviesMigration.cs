using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kino.Api.Migrations
{
    /// <inheritdoc />
    public partial class MoviesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviess_Authors_AuthorsId",
                table: "Moviess");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorsId",
                table: "Moviess",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Moviess_Authors_AuthorsId",
                table: "Moviess",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviess_Authors_AuthorsId",
                table: "Moviess");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorsId",
                table: "Moviess",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moviess_Authors_AuthorsId",
                table: "Moviess",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
