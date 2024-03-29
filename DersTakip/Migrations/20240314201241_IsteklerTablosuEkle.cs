﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DersTakip.Migrations
{
    /// <inheritdoc />
    public partial class IsteklerTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsteklerTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sonuc = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsteklerTbl", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsteklerTbl");
        }
    }
}
