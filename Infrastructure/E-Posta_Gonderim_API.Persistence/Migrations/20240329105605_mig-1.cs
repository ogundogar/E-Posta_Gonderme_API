using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Posta_Gonderim_API.Persistence.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullanıcıMailAdresleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: true),
                    TelefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullanıcıMailAdresleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SirketMailAdresleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortNumarasi = table.Column<int>(type: "int", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SirketMailAdresleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YollananMailler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketMailId = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YollananMailler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YollananMailler_SirketMailAdresleri_SirketMailId",
                        column: x => x.SirketMailId,
                        principalTable: "SirketMailAdresleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciMailAdresi_YollananMail",
                columns: table => new
                {
                    KullaniciMailAdresiId = table.Column<int>(type: "int", nullable: false),
                    YollananMailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciMailAdresi_YollananMail", x => new { x.YollananMailId, x.KullaniciMailAdresiId });
                    table.ForeignKey(
                        name: "FK_KullaniciMailAdresi_YollananMail_KullanıcıMailAdresleri_KullaniciMailAdresiId",
                        column: x => x.KullaniciMailAdresiId,
                        principalTable: "KullanıcıMailAdresleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciMailAdresi_YollananMail_YollananMailler_YollananMailId",
                        column: x => x.YollananMailId,
                        principalTable: "YollananMailler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciMailAdresi_YollananMail_KullaniciMailAdresiId",
                table: "KullaniciMailAdresi_YollananMail",
                column: "KullaniciMailAdresiId");

            migrationBuilder.CreateIndex(
                name: "IX_YollananMailler_SirketMailId",
                table: "YollananMailler",
                column: "SirketMailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciMailAdresi_YollananMail");

            migrationBuilder.DropTable(
                name: "KullanıcıMailAdresleri");

            migrationBuilder.DropTable(
                name: "YollananMailler");

            migrationBuilder.DropTable(
                name: "SirketMailAdresleri");
        }
    }
}
