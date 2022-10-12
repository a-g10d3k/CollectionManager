using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class cascadetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ParentId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ParentId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields",
                column: "ParentId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
