using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_AuthorId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_CollectionItems_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_CollectionItems_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_CollectionItems_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_AuthorId",
                table: "Collections",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_CollectionItems_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ParentId",
                table: "CustomDateFields",
                column: "ParentId",
                principalTable: "CollectionItems",
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
                name: "FK_CustomStringFields_CollectionItems_ParentId",
                table: "CustomStringFields",
                column: "ParentId",
                principalTable: "CollectionItems",
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
                name: "FK_CustomTextAreaFields_CollectionItems_ParentId",
                table: "CustomTextAreaFields",
                column: "ParentId",
                principalTable: "CollectionItems",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_AuthorId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_CollectionItems_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_CollectionItems_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_CollectionItems_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_AuthorId",
                table: "Collections",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_CollectionItems_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_ParentId",
                table: "CustomBoolFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ParentId",
                table: "CustomDateFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_Collections_ParentId",
                table: "CustomDateFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_CollectionItems_ParentId",
                table: "CustomStringFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_Collections_ParentId",
                table: "CustomStringFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_CollectionItems_ParentId",
                table: "CustomTextAreaFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_Collections_ParentId",
                table: "CustomTextAreaFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
