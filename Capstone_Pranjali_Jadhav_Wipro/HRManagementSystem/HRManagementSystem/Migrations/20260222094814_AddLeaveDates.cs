using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysRequested",
                table: "LeaveRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "LeaveRequests");

            migrationBuilder.AddColumn<int>(
                name: "DaysRequested",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
