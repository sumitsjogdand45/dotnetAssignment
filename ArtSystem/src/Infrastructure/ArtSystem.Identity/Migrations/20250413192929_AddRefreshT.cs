using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtSystem.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db0fdf7c-bdf7-40cb-8437-8ed66d54fc2e", "AQAAAAIAAYagAAAAEA0yBRP+bop7hnnHCUyc3g9mETW1z7HMJVsn3A2QVJ97iLdJRzI0f+zGzzMivYnvtQ==", "c1481b79-0fb5-421d-bed3-04404625818a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa39d772-a8d1-4675-a363-98b8a4590df7", "AQAAAAIAAYagAAAAEEwJFE0cUkEKGaxXFFQAYAk/5pQnSfLxZId26W6FY7h7Xr43ULgJMeHTDOzXtjhlGA==", "a07e2274-9ee1-4284-8bd4-0d43e077bd6d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eccbe434-65c0-4a3e-ab66-94d5de471fec", "AQAAAAIAAYagAAAAEA+p4TsvYO2uvZYDqp6z9f3qgpsae81WETdBGH2N6MNbG66caND+zYF+qbIVSNmX5g==", "c4bef8c2-12a9-4773-bdbd-8541aade150c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6a1e2c1-b706-4a3f-89c4-6d48d1a420de", "AQAAAAIAAYagAAAAELmXia3FeSGVcswk7vsvK8mV7GNqp3qSeaQnusmkWbzxbi3yLLl7kZS+dZqO1UgSHQ==", "251e1735-d518-4666-bcf9-d30cf6a2ae87" });
        }
    }
}
