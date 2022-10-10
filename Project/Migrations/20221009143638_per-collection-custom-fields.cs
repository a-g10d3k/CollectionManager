using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class percollectioncustomfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomBoolField_CollectionId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomIntField_CollectionId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomStringField_CollectionId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomTextAreaField_CollectionId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CollectionId",
                table: "CustomFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomBoolField_CollectionId",
                table: "CustomFields",
                column: "CustomBoolField_CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomIntField_CollectionId",
                table: "CustomFields",
                column: "CustomIntField_CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomStringField_CollectionId",
                table: "CustomFields",
                column: "CustomStringField_CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomTextAreaField_CollectionId",
                table: "CustomFields",
                column: "CustomTextAreaField_CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CollectionId",
                table: "CustomFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CustomBoolField_CollectionId",
                table: "CustomFields",
                column: "CustomBoolField_CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CustomIntField_CollectionId",
                table: "CustomFields",
                column: "CustomIntField_CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CustomStringField_CollectionId",
                table: "CustomFields",
                column: "CustomStringField_CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CustomTextAreaField_CollectionId",
                table: "CustomFields",
                column: "CustomTextAreaField_CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CustomBoolField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CustomIntField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CustomStringField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CustomTextAreaField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomBoolField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomIntField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomStringField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomTextAreaField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomBoolField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomIntField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomStringField_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomTextAreaField_CollectionId",
                table: "CustomFields");
        }
    }
}
