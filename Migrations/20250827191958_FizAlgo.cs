using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rplace_api.Migrations
{
    /// <inheritdoc />
    public partial class FizAlgo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Profiles_ProfileId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ProfileId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleID",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomSize",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Invites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_RoleID",
                table: "Profiles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Roles_RoleID",
                table: "Profiles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Roles_RoleID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_RoleID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "RoomSize",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Invites");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ProfileId",
                table: "Roles",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Profiles_ProfileId",
                table: "Roles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
