using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensagens.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MensagemPadrao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemPadrao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SessaoChat",
                columns: table => new
                {
                    IdSessaoChat = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioAbertura = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRecebido = table.Column<int>(type: "int", nullable: false),
                    Abertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaAtividade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusSessao = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    UsuarioAberturaId = table.Column<long>(type: "bigint", nullable: true),
                    UsuarioRecebidoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessaoChat", x => x.IdSessaoChat);
                    table.ForeignKey(
                        name: "FK_SessaoChat_Usuario_UsuarioAberturaId",
                        column: x => x.UsuarioAberturaId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessaoChat_Usuario_UsuarioRecebidoId",
                        column: x => x.UsuarioRecebidoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioEnvio = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRecebido = table.Column<int>(type: "int", nullable: false),
                    IdSessaoChat = table.Column<long>(type: "bigint", nullable: false),
                    IdMensagemPadrao = table.Column<long>(type: "bigint", nullable: true),
                    IdAcoes = table.Column<long>(type: "bigint", nullable: true),
                    Texto = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusMensagem = table.Column<int>(type: "int", nullable: false),
                    UsuarioAberturaId = table.Column<long>(type: "bigint", nullable: true),
                    UsuarioRecebidoId = table.Column<long>(type: "bigint", nullable: true),
                    SessaoIdSessaoChat = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Acao_IdAcoes",
                        column: x => x.IdAcoes,
                        principalTable: "Acao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_MensagemPadrao_IdMensagemPadrao",
                        column: x => x.IdMensagemPadrao,
                        principalTable: "MensagemPadrao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_SessaoChat_SessaoIdSessaoChat",
                        column: x => x.SessaoIdSessaoChat,
                        principalTable: "SessaoChat",
                        principalColumn: "IdSessaoChat");
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuarioAberturaId",
                        column: x => x.UsuarioAberturaId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuarioRecebidoId",
                        column: x => x.UsuarioRecebidoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_IdAcoes",
                table: "Mensagem",
                column: "IdAcoes");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_IdMensagemPadrao",
                table: "Mensagem",
                column: "IdMensagemPadrao");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_SessaoIdSessaoChat",
                table: "Mensagem",
                column: "SessaoIdSessaoChat");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuarioAberturaId",
                table: "Mensagem",
                column: "UsuarioAberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuarioRecebidoId",
                table: "Mensagem",
                column: "UsuarioRecebidoId");

            migrationBuilder.CreateIndex(
                name: "IX_SessaoChat_UsuarioAberturaId",
                table: "SessaoChat",
                column: "UsuarioAberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_SessaoChat_UsuarioRecebidoId",
                table: "SessaoChat",
                column: "UsuarioRecebidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropTable(
                name: "MensagemPadrao");

            migrationBuilder.DropTable(
                name: "SessaoChat");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
