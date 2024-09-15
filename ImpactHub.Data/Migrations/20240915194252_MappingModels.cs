using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImpactHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TB_IMPACTHUB_CADASTRO",
                newName: "NomeEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TB_IMPACTHUB_CADASTRO",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_TIPO_QUESTIONARIO)",
                columns: table => new
                {
                    IdTipoQuestionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoQuestionario = table.Column<string>(type: "varchar(15)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_TIPO_QUESTIONARIO)", x => x.IdTipoQuestionario);
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_QUESTIONARIO",
                columns: table => new
                {
                    IdQuestionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DescricaoPergunta = table.Column<string>(type: "varchar(225)", nullable: false),
                    DescricaoResposta = table.Column<string>(type: "varchar(225)", nullable: false),
                    IdTipoQuestionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_QUESTIONARIO", x => x.IdQuestionario);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_QUESTIONARIO_TB_IMPACTHUB_TIPO_QUESTIONARIO)_IdTipoQuestionario",
                        column: x => x.IdTipoQuestionario,
                        principalTable: "TB_IMPACTHUB_TIPO_QUESTIONARIO)",
                        principalColumn: "IdTipoQuestionario");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_RESULTADOS",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PorcentagemCertificado = table.Column<string>(type: "varchar(5)", nullable: false),
                    StatusResultado = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IdQuestionario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_RESULTADOS", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_RESULTADOS_TB_IMPACTHUB_QUESTIONARIO_IdQuestionario",
                        column: x => x.IdQuestionario,
                        principalTable: "TB_IMPACTHUB_QUESTIONARIO",
                        principalColumn: "IdQuestionario");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_MONITORAMENTO",
                columns: table => new
                {
                    IdMonitoramento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataValidade = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StatusMonitoramento = table.Column<string>(type: "varchar(15)", nullable: false),
                    DescricaoMonitoramento = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdResultado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_MONITORAMENTO", x => x.IdMonitoramento);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_LOGIN_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "TB_IMPACTHUB_LOGIN",
                        principalColumn: "IdLogin");
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_MONITORAMENTO_TB_IMPACTHUB_RESULTADOS_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "TB_IMPACTHUB_RESULTADOS",
                        principalColumn: "IdResultado");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_RANKINGS",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdRanking = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Posicao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_RANKINGS", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_RANKINGS_TB_IMPACTHUB_RESULTADOS_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "TB_IMPACTHUB_RESULTADOS",
                        principalColumn: "IdResultado");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_RELATORIO",
                columns: table => new
                {
                    IdRelatorio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Melhorias = table.Column<string>(type: "varchar(225)", nullable: false),
                    PontosFaltantesMelhorias = table.Column<string>(type: "varchar(225)", nullable: false),
                    StatusRelatorio = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdResultado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_RELATORIO", x => x.IdRelatorio);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_LOGIN_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "TB_IMPACTHUB_LOGIN",
                        principalColumn: "IdLogin");
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_RELATORIO_TB_IMPACTHUB_RESULTADOS_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "TB_IMPACTHUB_RESULTADOS",
                        principalColumn: "IdResultado");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_IdLogin",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_MONITORAMENTO_IdResultado",
                table: "TB_IMPACTHUB_MONITORAMENTO",
                column: "IdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_QUESTIONARIO_IdTipoQuestionario",
                table: "TB_IMPACTHUB_QUESTIONARIO",
                column: "IdTipoQuestionario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_IdLogin",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_RELATORIO_IdResultado",
                table: "TB_IMPACTHUB_RELATORIO",
                column: "IdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_RESULTADOS_IdQuestionario",
                table: "TB_IMPACTHUB_RESULTADOS",
                column: "IdQuestionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_MONITORAMENTO");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_RANKINGS");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_RELATORIO");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_RESULTADOS");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_QUESTIONARIO");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_TIPO_QUESTIONARIO)");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TB_IMPACTHUB_CADASTRO");

            migrationBuilder.RenameColumn(
                name: "NomeEmpresa",
                table: "TB_IMPACTHUB_CADASTRO",
                newName: "Nome");
        }
    }
}
