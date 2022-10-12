using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class cascadeitemfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
