using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.API.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Companies_Id",
                table: "Jobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Companies_Id",
                table: "Jobs",
                column: "Id",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
