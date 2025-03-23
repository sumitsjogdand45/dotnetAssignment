using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalLeaveDays = table.Column<double>(type: "float", nullable: false),
                    RemainingLeaveDays = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.BalanceId);
                    table.ForeignKey(
                        name: "FK_LeaveBalances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApprovals",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    ManagerIds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApprovals", x => x.ApprovalId);
                    table.ForeignKey(
                        name: "FK_LeaveApprovals_Users_ManagerIds",
                        column: x => x.ManagerIds,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveRequestUserId = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestId);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveApprovals_LeaveApprovalId",
                        column: x => x.LeaveApprovalId,
                        principalTable: "LeaveApprovals",
                        principalColumn: "ApprovalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Users_LeaveRequestUserId",
                        column: x => x.LeaveRequestUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_ManagerIds",
                table: "LeaveApprovals",
                column: "ManagerIds");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_UserId",
                table: "LeaveBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveApprovalId",
                table: "LeaveRequests",
                column: "LeaveApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveRequestUserId",
                table: "LeaveRequests",
                column: "LeaveRequestUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApprovals_LeaveRequests_LeaveRequestId",
                table: "LeaveApprovals",
                column: "LeaveRequestId",
                principalTable: "LeaveRequests",
                principalColumn: "LeaveRequestId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApprovals_LeaveRequests_LeaveRequestId",
                table: "LeaveApprovals");

            migrationBuilder.DropTable(
                name: "LeaveBalances");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeaveApprovals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
