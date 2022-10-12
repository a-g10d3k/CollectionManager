using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class collectionfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_CollectionId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_CollectionId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_CollectionId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_CollectionId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_Collections_CollectionId",
                table: "CustomTextAreaFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomTextAreaFields_CollectionId",
                table: "CustomTextAreaFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomStringFields_CollectionId",
                table: "CustomStringFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomIntFields_CollectionId",
                table: "CustomIntFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomDateFields_CollectionId",
                table: "CustomDateFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomBoolFields_CollectionId",
                table: "CustomBoolFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomTextAreaFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomStringFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomIntFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomDateFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomBoolFields");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomTextAreaFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomStringFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomIntFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomDateFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomBoolFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomTextAreaFields_CollectionId",
                table: "CustomTextAreaFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomStringFields_CollectionId",
                table: "CustomStringFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomIntFields_CollectionId",
                table: "CustomIntFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomDateFields_CollectionId",
                table: "CustomDateFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomBoolFields_CollectionId",
                table: "CustomBoolFields",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_CollectionId",
                table: "CustomBoolFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_Collections_CollectionId",
                table: "CustomDateFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_CollectionId",
                table: "CustomIntFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_Collections_CollectionId",
                table: "CustomStringFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_Collections_CollectionId",
                table: "CustomTextAreaFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
