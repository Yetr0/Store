using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class FavoriteGenreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "favoriteGenreId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_favoriteGenreId",
                table: "Customers",
                column: "favoriteGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Genres_favoriteGenreId",
                table: "Customers",
                column: "favoriteGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Genres_favoriteGenreId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_favoriteGenreId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "favoriteGenreId",
                table: "Customers");
        }
    }
}
