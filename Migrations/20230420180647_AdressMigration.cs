using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_NO.Migrations
{
    /// <inheritdoc />
    public partial class AdressMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adress_rl",
                columns: table => new
                {
                    cep = table.Column<string>(type: "text", nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    localidade = table.Column<string>(type: "text", nullable: true),
                    uf = table.Column<string>(type: "text", nullable: true),
                    ibge = table.Column<string>(type: "text", nullable: true),
                    gia = table.Column<string>(type: "text", nullable: true),
                    ddd = table.Column<string>(type: "text", nullable: true),
                    siafi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress_RL", x => x.cep);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress_RL");
        }
    }
}
