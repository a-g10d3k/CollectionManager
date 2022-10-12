using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class customfieldseparatefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_CustomIntFields_CollectionItems_ParentId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_ParentId",
                table: "CustomIntFields");

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

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CustomTextAreaFields",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomTextAreaFields_ParentId",
                table: "CustomTextAreaFields",
                newName: "IX_CustomTextAreaFields_ItemId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CustomStringFields",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomStringFields_ParentId",
                table: "CustomStringFields",
                newName: "IX_CustomStringFields_ItemId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CustomIntFields",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomIntFields_ParentId",
                table: "CustomIntFields",
                newName: "IX_CustomIntFields_ItemId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CustomDateFields",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomDateFields_ParentId",
                table: "CustomDateFields",
                newName: "IX_CustomDateFields_ItemId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CustomBoolFields",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomBoolFields_ParentId",
                table: "CustomBoolFields",
                newName: "IX_CustomBoolFields_ItemId");

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
                name: "FK_CustomBoolFields_CollectionItems_ItemId",
                table: "CustomBoolFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomBoolFields_Collections_CollectionId",
                table: "CustomBoolFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ItemId",
                table: "CustomDateFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomDateFields_Collections_CollectionId",
                table: "CustomDateFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ItemId",
                table: "CustomIntFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomIntFields_Collections_CollectionId",
                table: "CustomIntFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_CollectionItems_ItemId",
                table: "CustomStringFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStringFields_Collections_CollectionId",
                table: "CustomStringFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_CollectionItems_ItemId",
                table: "CustomTextAreaFields",
                column: "ItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomTextAreaFields_Collections_CollectionId",
                table: "CustomTextAreaFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_CollectionItems_ItemId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomBoolFields_Collections_CollectionId",
                table: "CustomBoolFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_CollectionItems_ItemId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomDateFields_Collections_CollectionId",
                table: "CustomDateFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_CollectionItems_ItemId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomIntFields_Collections_CollectionId",
                table: "CustomIntFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_CollectionItems_ItemId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomStringFields_Collections_CollectionId",
                table: "CustomStringFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomTextAreaFields_CollectionItems_ItemId",
                table: "CustomTextAreaFields");

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

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomTextAreaFields",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomTextAreaFields_ItemId",
                table: "CustomTextAreaFields",
                newName: "IX_CustomTextAreaFields_ParentId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomStringFields",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomStringFields_ItemId",
                table: "CustomStringFields",
                newName: "IX_CustomStringFields_ParentId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomIntFields",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomIntFields_ItemId",
                table: "CustomIntFields",
                newName: "IX_CustomIntFields_ParentId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomDateFields",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomDateFields_ItemId",
                table: "CustomDateFields",
                newName: "IX_CustomDateFields_ParentId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CustomBoolFields",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomBoolFields_ItemId",
                table: "CustomBoolFields",
                newName: "IX_CustomBoolFields_ParentId");

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
                principalColumn: "Id");

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
                principalColumn: "Id");

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
                principalColumn: "Id");

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
                principalColumn: "Id");

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
                principalColumn: "Id");
        }
    }
}
