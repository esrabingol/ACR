using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACR.DataAccess.Migrations
{
    public partial class secondCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Registers_OperatorId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Registers_RequesterId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Autoclaves");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "ReservationStatuses");

            migrationBuilder.DropColumn(
                name: "endTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Reservations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "requestNote",
                table: "Reservations",
                newName: "RequestNote");

            migrationBuilder.RenameColumn(
                name: "recipeCode",
                table: "Reservations",
                newName: "RecipeCode");

            migrationBuilder.RenameColumn(
                name: "projectName",
                table: "Reservations",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "partName",
                table: "Reservations",
                newName: "PartName");

            migrationBuilder.RenameColumn(
                name: "machineName",
                table: "Reservations",
                newName: "MachineName");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Reservations",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CancellationNote",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemNo = table.Column<int>(type: "int", nullable: true),
                    TcNumber = table.Column<int>(type: "int", nullable: true),
                    VpNumber = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperatorNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_OperatorId",
                table: "Reservations",
                column: "OperatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_RequesterId",
                table: "Reservations",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_OperatorId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_RequesterId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "CancellationNote",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Reservations",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "RequestNote",
                table: "Reservations",
                newName: "requestNote");

            migrationBuilder.RenameColumn(
                name: "RecipeCode",
                table: "Reservations",
                newName: "recipeCode");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Reservations",
                newName: "projectName");

            migrationBuilder.RenameColumn(
                name: "PartName",
                table: "Reservations",
                newName: "partName");

            migrationBuilder.RenameColumn(
                name: "MachineName",
                table: "Reservations",
                newName: "machineName");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Reservations",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "endTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Autoclaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemNo = table.Column<int>(type: "int", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineStatu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatorNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcNumber = table.Column<int>(type: "int", nullable: true),
                    VpNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoclaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CancellationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStatuses_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_RoleId",
                table: "Registers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatuses_ReservationId",
                table: "ReservationStatuses",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Registers_OperatorId",
                table: "Reservations",
                column: "OperatorId",
                principalTable: "Registers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Registers_RequesterId",
                table: "Reservations",
                column: "RequesterId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
