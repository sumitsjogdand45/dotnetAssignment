using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class conversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Drop the primary key constraint if ArtworkId is a primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_Artworks",
                table: "Artworks");

            // 2. Drop the old column
            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Artworks");

            // 3. Add the new column with IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // 4. Re-add primary key constraint (assuming ArtworkId is PK)
            migrationBuilder.AddPrimaryKey(
                name: "PK_Artworks",
                table: "Artworks",
                column: "ArtworkId");

            // 5. Optionally insert seed data
            //migrationBuilder.InsertData(
            //    table: "Artworks",
            //    columns: new[] { "ArtworkId", "CreationDate", "Description", "ImageURL", "Title" },
            //    values: new object[]
            //    {
            //1,s
            //new DateTime(2024, 1, 1),
            //"horse Painting",
            //"https://th.bing.com/th/id/OIP.aijJ8cc0jZng8oCWTiA1gQHaKT?w=146&h=180&c=7&r=0&o=5&pid=1.7",
            //"Painting"
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "ArtworkId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ArtworkId",
                table: "Artworks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.InsertData(
            //    table: "Artworks",
            //    columns: new[] { "ArtworkId", "CreationDate", "Description", "ImageURL", "Title" },
            //    values: new object[] { "1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "horse Painting", "https://th.bing.com/th/id/OIP.aijJ8cc0jZng8oCWTiA1gQHaKT?w=146&h=180&c=7&r=0&o=5&pid=1.7", "Painting" });


            // Drop the column
            migrationBuilder.DropColumn(
              name: "ArtworkId",
              table: "Artworks");

            // Optionally, recreate without IDENTITY if rolling back
            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);


        }
    }
}
