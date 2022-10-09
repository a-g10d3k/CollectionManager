using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class swapimagereferenc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionImage_Collections_CollectionId",
                table: "CollectionImage");

            migrationBuilder.DropIndex(
                name: "IX_CollectionImage_CollectionId",
                table: "CollectionImage");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CollectionImage");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ImageId",
                table: "Collections",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionImage_ImageId",
                table: "Collections",
                column: "ImageId",
                principalTable: "CollectionImage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionImage_ImageId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_ImageId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CollectionImage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionImage_CollectionId",
                table: "CollectionImage",
                column: "CollectionId",
                unique: true,
                filter: "[CollectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionImage_Collections_CollectionId",
                table: "CollectionImage",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
