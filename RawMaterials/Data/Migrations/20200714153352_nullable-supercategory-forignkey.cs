using Microsoft.EntityFrameworkCore.Migrations;

namespace RawMaterials.Data.Migrations
{
    public partial class nullablesupercategoryforignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<long>(
                name: "SuperCategoryId",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<long>(
                name: "SuperCategoryId",
                table: "Categories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
