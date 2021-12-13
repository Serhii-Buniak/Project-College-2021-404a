using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooStore.Migrations
{
    public partial class StoreDbMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductHistory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistory_ProductId",
                table: "ProductHistory",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProductHistory_ProductId",
                table: "ProductHistory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductHistory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductHistory",
                table: "ProductHistory",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
