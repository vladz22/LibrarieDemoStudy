using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarieDemo.Migrations
{
    public partial class UpdateProdusCheieStrainaCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Produsele",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produsele_CategorieId",
                table: "Produsele",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produsele_Categoriile_CategorieId",
                table: "Produsele",
                column: "CategorieId",
                principalTable: "Categoriile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produsele_Categoriile_CategorieId",
                table: "Produsele");

            migrationBuilder.DropIndex(
                name: "IX_Produsele_CategorieId",
                table: "Produsele");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Produsele");
        }
    }
}
