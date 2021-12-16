using Microsoft.EntityFrameworkCore.Migrations;

namespace BookListRazor.Migrations
{
    public partial class updatebooksnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CIdNameToken",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    NameToken = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TypeIdType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.NameToken);
                    table.ForeignKey(
                        name: "FK_Category_CategoryType_TypeIdType",
                        column: x => x.TypeIdType,
                        principalTable: "CategoryType",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CIdNameToken",
                table: "Book",
                column: "CIdNameToken");

            migrationBuilder.CreateIndex(
                name: "IX_Category_TypeIdType",
                table: "Category",
                column: "TypeIdType");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CIdNameToken",
                table: "Book",
                column: "CIdNameToken",
                principalTable: "Category",
                principalColumn: "NameToken",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CIdNameToken",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_Book_CIdNameToken",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CIdNameToken",
                table: "Book");
        }
    }
}
