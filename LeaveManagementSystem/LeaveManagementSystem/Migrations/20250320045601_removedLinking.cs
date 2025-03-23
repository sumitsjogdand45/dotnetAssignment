using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    public partial class removedLinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_LeaveApprovals_LeaveApprovalId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_LeaveApprovalId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals");

            migrationBuilder.DropColumn(
                name: "LeaveApprovalId",
                table: "LeaveRequests");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals");

            migrationBuilder.AddColumn<int>(
                name: "LeaveApprovalId",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveApprovalId",
                table: "LeaveRequests",
                column: "LeaveApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_LeaveApprovals_LeaveApprovalId",
                table: "LeaveRequests",
                column: "LeaveApprovalId",
                principalTable: "LeaveApprovals",
                principalColumn: "ApprovalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
