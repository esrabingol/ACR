using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACR.DataAccess.Migrations
{
    public partial class InitialCreatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Machines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Machines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Machines",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Machines");
        }
    }
}
