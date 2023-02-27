using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoarelaçãoentreSessãoeCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTeatherId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieTeatherId",
                table: "Sessions",
                column: "MovieTeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheater_MovieTeatherId",
                table: "Sessions",
                column: "MovieTeatherId",
                principalTable: "MovieTheater",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheater_MovieTeatherId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieTeatherId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MovieTeatherId",
                table: "Sessions");
        }
    }
}
