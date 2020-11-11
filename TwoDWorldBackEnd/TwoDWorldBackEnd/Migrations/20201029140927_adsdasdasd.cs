using Microsoft.EntityFrameworkCore.Migrations;

namespace TwoDWorldBackEnd.Migrations
{
    public partial class adsdasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenre_Genres_GenreId",
                table: "TitleGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenre_Titles_TitleId",
                table: "TitleGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleGenre",
                table: "TitleGenre");

            migrationBuilder.RenameTable(
                name: "TitleGenre",
                newName: "TitleGenres");

            migrationBuilder.RenameIndex(
                name: "IX_TitleGenre_TitleId",
                table: "TitleGenres",
                newName: "IX_TitleGenres_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_TitleGenre_GenreId",
                table: "TitleGenres",
                newName: "IX_TitleGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleGenres",
                table: "TitleGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenres_Genres_GenreId",
                table: "TitleGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenres_Titles_TitleId",
                table: "TitleGenres",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenres_Genres_GenreId",
                table: "TitleGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_TitleGenres_Titles_TitleId",
                table: "TitleGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TitleGenres",
                table: "TitleGenres");

            migrationBuilder.RenameTable(
                name: "TitleGenres",
                newName: "TitleGenre");

            migrationBuilder.RenameIndex(
                name: "IX_TitleGenres_TitleId",
                table: "TitleGenre",
                newName: "IX_TitleGenre_TitleId");

            migrationBuilder.RenameIndex(
                name: "IX_TitleGenres_GenreId",
                table: "TitleGenre",
                newName: "IX_TitleGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TitleGenre",
                table: "TitleGenre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenre_Genres_GenreId",
                table: "TitleGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TitleGenre_Titles_TitleId",
                table: "TitleGenre",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
