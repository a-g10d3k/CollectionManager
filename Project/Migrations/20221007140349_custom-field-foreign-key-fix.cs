using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class customfieldforeignkeyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomBoolField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomIntField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomStringField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomTextAreaField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemID",
                table: "CustomFields");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "CustomFields",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "CustomTextAreaField_ItemID",
                table: "CustomFields",
                newName: "CustomTextAreaField_ItemId");

            migrationBuilder.RenameColumn(
                name: "CustomStringField_ItemID",
                table: "CustomFields",
                newName: "CustomStringField_ItemId");

            migrationBuilder.RenameColumn(
                name: "CustomIntField_ItemID",
                table: "CustomFields",
                newName: "CustomIntField_ItemId");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField_ItemID",
                table: "CustomFields",
                newName: "CustomBoolField_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_ItemID",
                table: "CustomFields",
                newName: "IX_CustomFields_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomTextAreaField_ItemID",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomTextAreaField_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomStringField_ItemID",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomStringField_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomIntField_ItemID",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomIntField_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomBoolField_ItemID",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomBoolField_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomBoolField_ItemId",
                table: "CustomFields",
                column: "CustomBoolField_ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomIntField_ItemId",
                table: "CustomFields",
                column: "CustomIntField_ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomStringField_ItemId",
                table: "CustomFields",
                column: "CustomStringField_ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomTextAreaField_ItemId",
                table: "CustomFields",
                column: "CustomTextAreaField_ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemId",
                table: "CustomFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomBoolField_ItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomIntField_ItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomStringField_ItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomTextAreaField_ItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemId",
                table: "CustomFields");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomFields",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "CustomTextAreaField_ItemId",
                table: "CustomFields",
                newName: "CustomTextAreaField_ItemID");

            migrationBuilder.RenameColumn(
                name: "CustomStringField_ItemId",
                table: "CustomFields",
                newName: "CustomStringField_ItemID");

            migrationBuilder.RenameColumn(
                name: "CustomIntField_ItemId",
                table: "CustomFields",
                newName: "CustomIntField_ItemID");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField_ItemId",
                table: "CustomFields",
                newName: "CustomBoolField_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_ItemId",
                table: "CustomFields",
                newName: "IX_CustomFields_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomTextAreaField_ItemId",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomTextAreaField_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomStringField_ItemId",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomStringField_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomIntField_ItemId",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomIntField_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CustomBoolField_ItemId",
                table: "CustomFields",
                newName: "IX_CustomFields_CustomBoolField_ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomBoolField_ItemID",
                table: "CustomFields",
                column: "CustomBoolField_ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomIntField_ItemID",
                table: "CustomFields",
                column: "CustomIntField_ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomStringField_ItemID",
                table: "CustomFields",
                column: "CustomStringField_ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_CustomTextAreaField_ItemID",
                table: "CustomFields",
                column: "CustomTextAreaField_ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemID",
                table: "CustomFields",
                column: "ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id");
        }
    }
}
