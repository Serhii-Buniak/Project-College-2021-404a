using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooStore.Migrations
{
    public partial class StoreDbMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistory_Products_ProductId1",
                table: "ProductHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProductHistory_ProductId1",
                table: "ProductHistory");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductHistory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductHistory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistory_Products_ProductId",
                table: "ProductHistory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductHistory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "ProductId1",
                table: "ProductHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistory_ProductId1",
                table: "ProductHistory",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistory_Products_ProductId1",
                table: "ProductHistory",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
