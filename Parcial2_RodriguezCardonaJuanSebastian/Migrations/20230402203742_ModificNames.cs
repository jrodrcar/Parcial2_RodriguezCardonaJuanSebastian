using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_RodriguezCardonaJuanSebastian.Migrations
{
    /// <inheritdoc />
    public partial class ModificNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tickets_Id",
                table: "tickets",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tickets_Id",
                table: "tickets");
        }
    }
}
