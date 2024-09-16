using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImpactHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingModelsv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_CONTATO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_CONTATO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_ENDERECO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_LOGIN_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_LOGIN");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_LOGIN_IdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_LOGIN_IdLogin",
                table: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_IdLogin",
                table: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_IdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_LOGIN_IdCadastro",
                table: "TB_IMPACTHUB_LOGIN");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_ENDERECO_IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_CONTATO_IdCadastro",
                table: "TB_IMPACTHUB_CONTATO");

            migrationBuilder.DropColumn(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_LOGIN");

            migrationBuilder.DropColumn(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO");

            migrationBuilder.DropColumn(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_CONTATO");

            migrationBuilder.DropColumn(
                name: "IdLogin",
                table: "TB_IMPACTHUB_CADASTRO");

            migrationBuilder.AddColumn<int>(
                name: "LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAbertura",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "LoginIdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "LoginIdLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_LOGIN_LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "LoginIdLogin",
                principalTable: "TB_IMPACTHUB_LOGIN",
                principalColumn: "IdLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_LOGIN_LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "LoginIdLogin",
                principalTable: "TB_IMPACTHUB_LOGIN",
                principalColumn: "IdLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_LOGIN_LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_LOGIN_LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropColumn(
                name: "LoginIdLogin",
                table: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropColumn(
                name: "LoginIdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "TB_IMPACTHUB_CADASTRO");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "TB_IMPACTHUB_CADASTRO");

            migrationBuilder.AddColumn<int>(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_LOGIN",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCadastro",
                table: "TB_IMPACTHUB_CONTATO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DataAbertura",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "NVARCHAR2(10)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AddColumn<int>(
                name: "IdLogin",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_IdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_IdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_LOGIN_IdCadastro",
                table: "TB_IMPACTHUB_LOGIN",
                column: "IdCadastro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_ENDERECO_IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO",
                column: "IdCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_CONTATO_IdCadastro",
                table: "TB_IMPACTHUB_CONTATO",
                column: "IdCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_CONTATO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_CONTATO",
                column: "IdCadastro",
                principalTable: "TB_IMPACTHUB_CADASTRO",
                principalColumn: "IdCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_ENDERECO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO",
                column: "IdCadastro",
                principalTable: "TB_IMPACTHUB_CADASTRO",
                principalColumn: "IdCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_LOGIN_TB_IMPACTHUB_CADASTRO_IdCadastro",
                table: "TB_IMPACTHUB_LOGIN",
                column: "IdCadastro",
                principalTable: "TB_IMPACTHUB_CADASTRO",
                principalColumn: "IdCadastro");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_LOGIN_IdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "IdLogin",
                principalTable: "TB_IMPACTHUB_LOGIN",
                principalColumn: "IdLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_LOGIN_IdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "IdLogin",
                principalTable: "TB_IMPACTHUB_LOGIN",
                principalColumn: "IdLogin");
        }
    }
}
