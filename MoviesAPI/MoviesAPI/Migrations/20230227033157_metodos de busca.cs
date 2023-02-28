using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class metodosdebusca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Addresses_AddressId",
                table: "MovieTheater");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Addresses_AddressId",
                table: "MovieTheater",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Addresses_AddressId",
                table: "MovieTheater");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Addresses_AddressId",
                table: "MovieTheater",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
