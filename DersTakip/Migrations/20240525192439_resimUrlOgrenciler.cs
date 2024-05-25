﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersTakip.Migrations
{
    /// <inheritdoc />
    public partial class resimUrlOgrenciler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "OgrencilerTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "OgrencilerTbl");
        }
    }
}
