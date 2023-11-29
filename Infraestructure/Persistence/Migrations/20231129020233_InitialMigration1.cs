using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _03.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Employees_EmployeeNavigationId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeNavigationId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeeNavigationId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionTypeNavigationId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "EmployeeNavigationId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionTypeNavigationId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Employee",
                table: "Permissions",
                column: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionType",
                table: "Permissions",
                column: "PermissionType");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Permissions",
                table: "Permissions",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionType_Permissions",
                table: "Permissions",
                column: "PermissionType",
                principalTable: "PermissionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Permissions",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionType_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_Employee",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionType",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeNavigationId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionTypeNavigationId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeeNavigationId",
                table: "Permissions",
                column: "EmployeeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeNavigationId",
                table: "Permissions",
                column: "PermissionTypeNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Employees_EmployeeNavigationId",
                table: "Permissions",
                column: "EmployeeNavigationId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeNavigationId",
                table: "Permissions",
                column: "PermissionTypeNavigationId",
                principalTable: "PermissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
