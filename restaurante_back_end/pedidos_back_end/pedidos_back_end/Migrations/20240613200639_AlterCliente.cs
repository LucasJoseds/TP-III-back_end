using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pedidos_back_end.Migrations
{
    /// <inheritdoc />
    public partial class AlterCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Clientes");
        }
    }
}
