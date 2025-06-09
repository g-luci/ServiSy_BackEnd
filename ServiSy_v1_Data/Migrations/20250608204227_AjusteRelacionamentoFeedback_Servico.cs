using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiSy_v1_Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoFeedback_Servico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Servicos_ServicoId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Usuarios_UsuarioId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Usuarios_PrestadorId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_PrestadorId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ServicoId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UsuarioId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Feedbacks");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Prestado_Id",
                table: "Servicos",
                column: "Prestado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Servico_Id",
                table: "Feedbacks",
                column: "Servico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Usuario_Id",
                table: "Feedbacks",
                column: "Usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Servicos_Servico_Id",
                table: "Feedbacks",
                column: "Servico_Id",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Usuarios_Usuario_Id",
                table: "Feedbacks",
                column: "Usuario_Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Usuarios_Prestado_Id",
                table: "Servicos",
                column: "Prestado_Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Servicos_Servico_Id",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Usuarios_Usuario_Id",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Usuarios_Prestado_Id",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_Prestado_Id",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Servico_Id",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Usuario_Id",
                table: "Feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "PrestadorId",
                table: "Servicos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicoId",
                table: "Feedbacks",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Feedbacks",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_PrestadorId",
                table: "Servicos",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ServicoId",
                table: "Feedbacks",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UsuarioId",
                table: "Feedbacks",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Servicos_ServicoId",
                table: "Feedbacks",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Usuarios_UsuarioId",
                table: "Feedbacks",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Usuarios_PrestadorId",
                table: "Servicos",
                column: "PrestadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
