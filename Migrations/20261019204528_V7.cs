using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoImmo.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MouvementsStock_ArticleId_Date",
                table: "MouvementsStock");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Cible_CibleId",
                table: "Documents");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reclamations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cible",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NomComplet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DocumentsEmis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SousTitre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmisPar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empreinte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsEmis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametresSociete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifiants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PiedDePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPublique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LogoMime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SignatureMime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignataireNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignataireFonction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametresSociete", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reclamations_ClientId",
                table: "Reclamations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MouvementsStock_ArticleId",
                table: "MouvementsStock",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsEmis_Code",
                table: "DocumentsEmis",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamations_Clients_ClientId",
                table: "Reclamations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamations_Clients_ClientId",
                table: "Reclamations");

            migrationBuilder.DropTable(
                name: "DocumentsEmis");

            migrationBuilder.DropTable(
                name: "ParametresSociete");

            migrationBuilder.DropIndex(
                name: "IX_Reclamations_ClientId",
                table: "Reclamations");

            migrationBuilder.DropIndex(
                name: "IX_MouvementsStock_ArticleId",
                table: "MouvementsStock");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reclamations");

            migrationBuilder.AlterColumn<string>(
                name: "Cible",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomComplet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MouvementsStock_ArticleId_Date",
                table: "MouvementsStock",
                columns: new[] { "ArticleId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Cible_CibleId",
                table: "Documents",
                columns: new[] { "Cible", "CibleId" });
        }
    }
}
