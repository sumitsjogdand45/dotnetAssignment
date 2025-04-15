using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtSystem.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a", "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a", "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a", null, "Administrator", "ADMINISTRATOR" },
                    { "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a", 0, "3e0c9c4e-3e6b-4089-9ea1-3807933d2777", "ApplicationUser", "admin@gmail.com", false, "Admin", "System", false, null, "ADMIN@GMAIL.COM", "admin@gmail.com", "AQAAAAIAAYagAAAAEGSerIkg3MGWzvIqYBqRX8qvlG3yLXEpqT4VOGpGOJxQGxKQIRoqJI6e7j57DC5Vdg==", null, false, "76262a2a-5db2-4cbd-a65d-d9175fa8644c", false, "admin@gmail.com" },
                    { "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a", 0, "b772dd51-91dd-46d6-8a92-546d50f77a46", "ApplicationUser", "sunny@gmail.com", false, "sunny", "Jadhav", false, null, "SUNNY@GMAIL.COM", "sunny@gmail.com", "AQAAAAIAAYagAAAAEOo140YCjSyf1jfSCSaoPTSIQOyIyDU5AAFCiR0NehMp7LrVGabZvvZ0rxLBNY+b5Q==", null, false, "bbe8f2e4-022d-4130-b96a-880211eee80c", false, "sunny@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a", "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a" },
                    { "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a", "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a" }
                });
        }
    }
}
