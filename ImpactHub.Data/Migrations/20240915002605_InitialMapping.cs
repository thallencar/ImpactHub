using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImpactHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_CADASTRO",
                columns: table => new
                {
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(8)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(180)", nullable: false),
                    Porte = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataAbertura = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_CADASTRO", x => x.IdCadastro);
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_CONTATO",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Ddi = table.Column<int>(type: "NUMBER(10)", maxLength: 3, nullable: false),
                    Ddd = table.Column<int>(type: "NUMBER(10)", maxLength: 3, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: false),
                    TipoContato = table.Column<string>(type: "varchar(25)", nullable: false),
                    StatusContato = table.Column<string>(type: "varchar(25)", nullable: false),
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_CONTATO", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_CONTATO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                        column: x => x.IdCadastro,
                        principalTable: "TB_IMPACTHUB_CADASTRO",
                        principalColumn: "IdCadastro");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_ENDERECO",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(80)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(125)", nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", maxLength: 5, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(125)", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(150)", nullable: true),
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_ENDERECO", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_ENDERECO_TB_IMPACTHUB_CADASTRO_IdCadastro",
                        column: x => x.IdCadastro,
                        principalTable: "TB_IMPACTHUB_CADASTRO",
                        principalColumn: "IdCadastro");
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPACTHUB_LOGIN",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeUsuario = table.Column<string>(type: "varchar(80)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(16)", nullable: false),
                    StatusLogin = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPACTHUB_LOGIN", x => x.IdLogin);
                    table.ForeignKey(
                        name: "FK_TB_IMPACTHUB_LOGIN_TB_IMPACTHUB_CADASTRO_IdCadastro",
                        column: x => x.IdCadastro,
                        principalTable: "TB_IMPACTHUB_CADASTRO",
                        principalColumn: "IdCadastro");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_CONTATO_IdCadastro",
                table: "TB_IMPACTHUB_CONTATO",
                column: "IdCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_ENDERECO_IdCadastro",
                table: "TB_IMPACTHUB_ENDERECO",
                column: "IdCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPACTHUB_LOGIN_IdCadastro",
                table: "TB_IMPACTHUB_LOGIN",
                column: "IdCadastro",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_CONTATO");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_IMPACTHUB_CADASTRO");
        }
    }
}
