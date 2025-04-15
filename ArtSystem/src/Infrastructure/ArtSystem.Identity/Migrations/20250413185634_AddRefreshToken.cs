using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtSystem.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a", 0, "eccbe434-65c0-4a3e-ab66-94d5de471fec", "admin@gmail.com", false, "Admin", "System", false, null, "ADMIN@GMAIL.COM", "admin@gmail.com", "AQAAAAIAAYagAAAAEA+p4TsvYO2uvZYDqp6z9f3qgpsae81WETdBGH2N6MNbG66caND+zYF+qbIVSNmX5g==", null, false, "c4bef8c2-12a9-4773-bdbd-8541aade150c", false, "admin@gmail.com" },
                    { "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a", 0, "c6a1e2c1-b706-4a3f-89c4-6d48d1a420de", "sunny@gmail.com", false, "sunny", "Jadhav", false, null, "SUNNY@GMAIL.COM", "sunny@gmail.com", "AQAAAAIAAYagAAAAELmXia3FeSGVcswk7vsvK8mV7GNqp3qSeaQnusmkWbzxbi3yLLl7kZS+dZqO1UgSHQ==", null, false, "251e1735-d518-4666-bcf9-d30cf6a2ae87", false, "sunny@gmail.com" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
