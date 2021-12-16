using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class newBookdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryType_TypeIdType",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_Category_TypeIdType",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "TypeIdType",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Book",
                table: "CategoryType",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType",
                column: "Name");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryType_Category_Book",
                table: "CategoryType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_CategoryType_Book",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "CategoryType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CategoryType",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeIdType",
                table: "Category",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Category_TypeIdType",
                table: "Category",
                column: "TypeIdType");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryType_TypeIdType",
                table: "Category",
                column: "TypeIdType",
                principalTable: "CategoryType",
                principalColumn: "Type",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
