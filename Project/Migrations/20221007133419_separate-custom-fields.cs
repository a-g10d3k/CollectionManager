using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class separatecustomfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemID",
                table: "CustomFields");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "CustomFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomBoolField_ItemID",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomIntField_ItemID",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomStringField_ItemID",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomTextAreaField_ItemID",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_CollectionItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "CollectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomBoolField_ItemID",
                table: "CustomFields",
                column: "CustomBoolField_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomIntField_ItemID",
                table: "CustomFields",
                column: "CustomIntField_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomStringField_ItemID",
                table: "CustomFields",
                column: "CustomStringField_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomTextAreaField_ItemID",
                table: "CustomFields",
                column: "CustomTextAreaField_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ItemID",
                table: "Tag",
                column: "ItemID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomBoolField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomIntField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomStringField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomTextAreaField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomBoolField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomIntField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomStringField_ItemID",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomTextAreaField_ItemID",
                table: "CustomFields");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "CustomFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CollectionItems_ItemID",
                table: "CustomFields",
                column: "ItemID",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
