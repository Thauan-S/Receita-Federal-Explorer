using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkerService1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cnaes",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnaes", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "NaturezasJuridicas",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturezasJuridicas", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "QualificacoesSocios",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificacoesSocios", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj_basico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razao_social = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualificacao_responsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capital_social = table.Column<float>(type: "real", nullable: true),
                    porte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ente_responsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    natureza_juridica_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empresa_NaturezasJuridicas_natureza_juridica_id",
                        column: x => x.natureza_juridica_id,
                        principalTable: "NaturezasJuridicas",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj_basico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj_ordem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj_dv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matriz_filial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_fantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situacao_cadastral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_situacao_cadastral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_cidade_exterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_inicio_atividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnae_fiscal_secundario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ddd1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ddd2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ddd_fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone_fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correio_eletronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situacao_especial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_situacao_especial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motivo_situacao_cadastral_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    empresa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    municipio_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    pais_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cnae_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Cnaes_cnae_id",
                        column: x => x.cnae_id,
                        principalTable: "Cnaes",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "Empresa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Motivos_motivo_situacao_cadastral_id",
                        column: x => x.motivo_situacao_cadastral_id,
                        principalTable: "Motivos",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Municipios_municipio_id",
                        column: x => x.municipio_id,
                        principalTable: "Municipios",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Paises_pais_id",
                        column: x => x.pais_id,
                        principalTable: "Paises",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateTable(
                name: "Simples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj_basico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empresa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    opcao_pelo_simples = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_opcao_simples = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_exclusao_simples = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opcao_pelo_mei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_opcao_mei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_exclusao_mei = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simples", x => x.id);
                    table.ForeignKey(
                        name: "FK_Simples_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "Empresa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnpj_basico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identificador_socio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_socio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj_cpf_socio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_entrada_sociedade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_cpf_representante_legal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_representante_legal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_qualificacao_representante_legal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faixa_etaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualificacao_socio_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    empresa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    pais_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Socios_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "Empresa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Socios_Paises_pais_id",
                        column: x => x.pais_id,
                        principalTable: "Paises",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_Socios_QualificacoesSocios_qualificacao_socio_id",
                        column: x => x.qualificacao_socio_id,
                        principalTable: "QualificacoesSocios",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_natureza_juridica_id",
                table: "Empresa",
                column: "natureza_juridica_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_cnae_id",
                table: "Estabelecimentos",
                column: "cnae_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_empresa_id",
                table: "Estabelecimentos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_motivo_situacao_cadastral_id",
                table: "Estabelecimentos",
                column: "motivo_situacao_cadastral_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_municipio_id",
                table: "Estabelecimentos",
                column: "municipio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_pais_id",
                table: "Estabelecimentos",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_Simples_empresa_id",
                table: "Simples",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_empresa_id",
                table: "Socios",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_pais_id",
                table: "Socios",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_qualificacao_socio_id",
                table: "Socios",
                column: "qualificacao_socio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Simples");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Cnaes");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "QualificacoesSocios");

            migrationBuilder.DropTable(
                name: "NaturezasJuridicas");
        }
    }
}
