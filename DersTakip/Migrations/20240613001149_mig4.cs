using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersTakip.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenlerId",
                table: "ProgramHftkTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "ProgramHftkTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ProgramHftkTbl_OgretmenlerId",
                table: "ProgramHftkTbl",
                column: "OgretmenlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramHftkTbl_OgretmenlerTbl_OgretmenlerId",
                table: "ProgramHftkTbl",
                column: "OgretmenlerId",
                principalTable: "OgretmenlerTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramHftkTbl_OgretmenlerTbl_OgretmenlerId",
                table: "ProgramHftkTbl");

            migrationBuilder.DropIndex(
                name: "IX_ProgramHftkTbl_OgretmenlerId",
                table: "ProgramHftkTbl");

            migrationBuilder.DropColumn(
                name: "OgretmenlerId",
                table: "ProgramHftkTbl");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "ProgramHftkTbl");
        }
    }
}
