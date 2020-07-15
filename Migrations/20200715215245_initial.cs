using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeroWaste.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    IDFamilias = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    Rendimento = table.Column<int>(nullable: false),
                    NumeroPessoasAgregado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.IDFamilias);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    IDInstituicoes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    NumeroPessoasAbrangidas = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.IDInstituicoes);
                });

            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    RegrasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Rendimento = table.Column<int>(nullable: false),
                    Agregado = table.Column<int>(nullable: false),
                    Pedidos = table.Column<int>(nullable: false),
                    Alimentos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.RegrasID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    IDRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.IDRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "Supermercado",
                columns: table => new
                {
                    IDSupermercado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermercado", x => x.IDSupermercado);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    IDTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.IDTipo);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    IDVoluntarios = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    NrTotalEntregas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.IDVoluntarios);
                });

            migrationBuilder.CreateTable(
                name: "RefeicoesRestaurante",
                columns: table => new
                {
                    IDRefeicoesRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    IDRestaurante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicoesRestaurante", x => x.IDRefeicoesRestaurante);
                    table.ForeignKey(
                        name: "FK_RefeicoesRestaurante_Restaurante_IDRestaurante",
                        column: x => x.IDRestaurante,
                        principalTable: "Restaurante",
                        principalColumn: "IDRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosSupermercado",
                columns: table => new
                {
                    IDProdutosSupermercado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    IDSupermercado = table.Column<int>(nullable: false),
                    IDTipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosSupermercado", x => x.IDProdutosSupermercado);
                    table.ForeignKey(
                        name: "FK_ProdutosSupermercado_Supermercado_IDSupermercado",
                        column: x => x.IDSupermercado,
                        principalTable: "Supermercado",
                        principalColumn: "IDSupermercado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosSupermercado_Tipo_IDTipo",
                        column: x => x.IDTipo,
                        principalTable: "Tipo",
                        principalColumn: "IDTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoRestaurante",
                columns: table => new
                {
                    IDPedidoRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    EstadoEntrega = table.Column<bool>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    IDFamilias = table.Column<int>(nullable: false),
                    IDInstituicoes = table.Column<int>(nullable: false),
                    IDRefeicoesRestaurante = table.Column<int>(nullable: false),
                    IDVoluntarios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoRestaurante", x => x.IDPedidoRestaurante);
                    table.ForeignKey(
                        name: "FK_PedidoRestaurante_Familias_IDFamilias",
                        column: x => x.IDFamilias,
                        principalTable: "Familias",
                        principalColumn: "IDFamilias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoRestaurante_Instituicoes_IDInstituicoes",
                        column: x => x.IDInstituicoes,
                        principalTable: "Instituicoes",
                        principalColumn: "IDInstituicoes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoRestaurante_RefeicoesRestaurante_IDRefeicoesRestaurante",
                        column: x => x.IDRefeicoesRestaurante,
                        principalTable: "RefeicoesRestaurante",
                        principalColumn: "IDRefeicoesRestaurante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoRestaurante_Voluntarios_IDVoluntarios",
                        column: x => x.IDVoluntarios,
                        principalTable: "Voluntarios",
                        principalColumn: "IDVoluntarios",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoSupermercado",
                columns: table => new
                {
                    IDPedidoSupermercado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    EstadoEntrega = table.Column<bool>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    IDFamilias = table.Column<int>(nullable: false),
                    IDInstituicoes = table.Column<int>(nullable: false),
                    IDProdutosSupermercado = table.Column<int>(nullable: false),
                    IDVoluntarios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSupermercado", x => x.IDPedidoSupermercado);
                    table.ForeignKey(
                        name: "FK_PedidoSupermercado_Familias_IDFamilias",
                        column: x => x.IDFamilias,
                        principalTable: "Familias",
                        principalColumn: "IDFamilias",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoSupermercado_Instituicoes_IDInstituicoes",
                        column: x => x.IDInstituicoes,
                        principalTable: "Instituicoes",
                        principalColumn: "IDInstituicoes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoSupermercado_ProdutosSupermercado_IDProdutosSupermercado",
                        column: x => x.IDProdutosSupermercado,
                        principalTable: "ProdutosSupermercado",
                        principalColumn: "IDProdutosSupermercado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoSupermercado_Voluntarios_IDVoluntarios",
                        column: x => x.IDVoluntarios,
                        principalTable: "Voluntarios",
                        principalColumn: "IDVoluntarios",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRestaurante_IDFamilias",
                table: "PedidoRestaurante",
                column: "IDFamilias");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRestaurante_IDInstituicoes",
                table: "PedidoRestaurante",
                column: "IDInstituicoes");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRestaurante_IDRefeicoesRestaurante",
                table: "PedidoRestaurante",
                column: "IDRefeicoesRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoRestaurante_IDVoluntarios",
                table: "PedidoRestaurante",
                column: "IDVoluntarios");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSupermercado_IDFamilias",
                table: "PedidoSupermercado",
                column: "IDFamilias");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSupermercado_IDInstituicoes",
                table: "PedidoSupermercado",
                column: "IDInstituicoes");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSupermercado_IDProdutosSupermercado",
                table: "PedidoSupermercado",
                column: "IDProdutosSupermercado");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSupermercado_IDVoluntarios",
                table: "PedidoSupermercado",
                column: "IDVoluntarios");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosSupermercado_IDSupermercado",
                table: "ProdutosSupermercado",
                column: "IDSupermercado");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosSupermercado_IDTipo",
                table: "ProdutosSupermercado",
                column: "IDTipo");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicoesRestaurante_IDRestaurante",
                table: "RefeicoesRestaurante",
                column: "IDRestaurante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoRestaurante");

            migrationBuilder.DropTable(
                name: "PedidoSupermercado");

            migrationBuilder.DropTable(
                name: "Regras");

            migrationBuilder.DropTable(
                name: "RefeicoesRestaurante");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "ProdutosSupermercado");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Supermercado");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
