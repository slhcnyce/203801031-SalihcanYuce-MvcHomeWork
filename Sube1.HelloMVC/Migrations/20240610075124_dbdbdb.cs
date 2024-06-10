using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube1.HelloMVC.Migrations
{
    /// <inheritdoc />
    public partial class dbdbdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciDersler_tblDersler_DersId",
                table: "OgrenciDersler");

            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciDersler_tblOgrenciler_OgrenciId",
                table: "OgrenciDersler");

            migrationBuilder.RenameColumn(
                name: "DersId",
                table: "OgrenciDersler",
                newName: "Dersid");

            migrationBuilder.RenameColumn(
                name: "OgrenciId",
                table: "OgrenciDersler",
                newName: "Ogrenciid");

            migrationBuilder.RenameIndex(
                name: "IX_OgrenciDersler_DersId",
                table: "OgrenciDersler",
                newName: "IX_OgrenciDersler_Dersid");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciDersler_tblDersler_Dersid",
                table: "OgrenciDersler",
                column: "Dersid",
                principalTable: "tblDersler",
                principalColumn: "Dersid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciDersler_tblOgrenciler_Ogrenciid",
                table: "OgrenciDersler",
                column: "Ogrenciid",
                principalTable: "tblOgrenciler",
                principalColumn: "Ogrenciid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciDersler_tblDersler_Dersid",
                table: "OgrenciDersler");

            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciDersler_tblOgrenciler_Ogrenciid",
                table: "OgrenciDersler");

            migrationBuilder.RenameColumn(
                name: "Dersid",
                table: "OgrenciDersler",
                newName: "DersId");

            migrationBuilder.RenameColumn(
                name: "Ogrenciid",
                table: "OgrenciDersler",
                newName: "OgrenciId");

            migrationBuilder.RenameIndex(
                name: "IX_OgrenciDersler_Dersid",
                table: "OgrenciDersler",
                newName: "IX_OgrenciDersler_DersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciDersler_tblDersler_DersId",
                table: "OgrenciDersler",
                column: "DersId",
                principalTable: "tblDersler",
                principalColumn: "Dersid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciDersler_tblOgrenciler_OgrenciId",
                table: "OgrenciDersler",
                column: "OgrenciId",
                principalTable: "tblOgrenciler",
                principalColumn: "Ogrenciid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
