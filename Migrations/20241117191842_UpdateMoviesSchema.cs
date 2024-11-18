using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smdb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMoviesSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Movies",
                newName: "CoverImageUrl");

            migrationBuilder.AddColumn<List<string>>(
                name: "ImageUrls",
                table: "Movies",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Movies",
                newName: "ImageUrl");
        }
    }
}
