using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    public partial class renamedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApprovals_Users_ManagerIds",
                table: "LeaveApprovals");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_ManagerIds",
                table: "LeaveApprovals");

            migrationBuilder.DropColumn(
                name: "ManagerIds",
                table: "LeaveApprovals");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_ManagerId",
                table: "LeaveApprovals",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApprovals_Users_ManagerId",
                table: "LeaveApprovals",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApprovals_Users_ManagerId",
                table: "LeaveApprovals");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_ManagerId",
                table: "LeaveApprovals");

            migrationBuilder.AddColumn<int>(
                name: "ManagerIds",
                table: "LeaveApprovals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_ManagerIds",
                table: "LeaveApprovals",
                column: "ManagerIds");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApprovals_Users_ManagerIds",
                table: "LeaveApprovals",
                column: "ManagerIds",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
