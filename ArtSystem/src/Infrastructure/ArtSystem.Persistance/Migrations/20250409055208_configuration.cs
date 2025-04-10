using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "ArtworkId", "CreationDate", "Description", "ImageURL", "Title" },
                values: new object[] { "1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "horse Painting", "https://th.bing.com/th/id/OIP.aijJ8cc0jZng8oCWTiA1gQHaKT?w=146&h=180&c=7&r=0&o=5&pid=1.7", "Painting" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "ArtworkId",
                keyValue: "1");
        }
    }
}
