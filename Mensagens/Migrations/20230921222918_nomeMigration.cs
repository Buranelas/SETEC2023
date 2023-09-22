using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensagens.Migrations
{
    /// <inheritdoc />
    public partial class nomeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndiceAnterior",
                table: "MensagemPadrao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndiceArvore",
                table: "MensagemPadrao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProximoIndice",
                table: "MensagemPadrao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Texto",
                table: "MensagemPadrao",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Acao",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoAcao",
                table: "Acao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndiceAnterior",
                table: "MensagemPadrao");

            migrationBuilder.DropColumn(
                name: "IndiceArvore",
                table: "MensagemPadrao");

            migrationBuilder.DropColumn(
                name: "ProximoIndice",
                table: "MensagemPadrao");

            migrationBuilder.DropColumn(
                name: "Texto",
                table: "MensagemPadrao");

            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "TipoAcao",
                table: "Acao");
        }
    }
}
