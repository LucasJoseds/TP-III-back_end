using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pedidos_back_end.Migrations
{
    /// <inheritdoc />
    public partial class InsereImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidade",
                table: "Cardapios");

            migrationBuilder.AddColumn<string>(
                name: "ImagemCardapio",
                table: "Cardapios",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemCardapio",
                table: "Cardapios");

            migrationBuilder.AddColumn<bool>(
                name: "Disponibilidade",
                table: "Cardapios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
