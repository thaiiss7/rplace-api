using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rplace_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GiftCards",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiftCards_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receiverid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemRooms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pixels",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Green = table.Column<int>(type: "int", nullable: false),
                    Blue = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pixels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profiles_ItemRooms_ItemRoomId",
                        column: x => x.ItemRoomId,
                        principalTable: "ItemRooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Profiles_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleRoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roles_ItemRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "ItemRooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Roles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Rooms_RoleRoomID",
                        column: x => x.RoleRoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiftCards_PlanId",
                table: "GiftCards",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_Receiverid",
                table: "Invites",
                column: "Receiverid");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_RoomId",
                table: "Invites",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_SenderId",
                table: "Invites",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRooms_RoomId",
                table: "ItemRooms",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pixels_RoomId",
                table: "Pixels",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ItemRoomId",
                table: "Profiles",
                column: "ItemRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlanId",
                table: "Profiles",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_RoomID",
                table: "Profiles",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ProfileId",
                table: "Roles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleRoomID",
                table: "Roles",
                column: "RoleRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoomId",
                table: "Roles",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ProfileId",
                table: "Rooms",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Profiles_Receiverid",
                table: "Invites",
                column: "Receiverid",
                principalTable: "Profiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Profiles_SenderId",
                table: "Invites",
                column: "SenderId",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Rooms_RoomId",
                table: "Invites",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRooms_Rooms_RoomId",
                table: "ItemRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pixels_Rooms_RoomId",
                table: "Pixels",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Rooms_RoomID",
                table: "Profiles",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Plans_PlanId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Profiles_ProfileId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "GiftCards");

            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropTable(
                name: "Pixels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ItemRooms");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
