using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class newBooksmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryType_Category_Book",
                table: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_CategoryType_Book",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "CategoryType");

            migrationBuilder.AddColumn<string>(
                name: "TypeIdName",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_TypeIdName",
                table: "Category",
                column: "TypeIdName");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryType_TypeIdName",
                table: "Category",
                column: "TypeIdName",
                principalTable: "CategoryType",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryType_TypeIdName",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_TypeIdName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TypeIdName",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Book",
                table: "CategoryType",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_Book",
                table: "CategoryType",
                column: "Book",
                unique: true,
                filter: "[Book] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryType_Category_Book",
                table: "CategoryType",
                column: "Book",
                principalTable: "Category",
                principalColumn: "NameToken",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
