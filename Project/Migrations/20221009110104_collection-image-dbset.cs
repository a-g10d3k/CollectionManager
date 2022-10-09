using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class collectionimagedbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionImage_ImageId",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionImage",
                table: "CollectionImage");

            migrationBuilder.RenameTable(
                name: "CollectionImage",
                newName: "CollectionImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionImages",
                table: "CollectionImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionImages_ImageId",
                table: "Collections",
                column: "ImageId",
                principalTable: "CollectionImages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionImages_ImageId",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionImages",
                table: "CollectionImages");

            migrationBuilder.RenameTable(
                name: "CollectionImages",
                newName: "CollectionImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionImage",
                table: "CollectionImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionImage_ImageId",
                table: "Collections",
                column: "ImageId",
                principalTable: "CollectionImage",
                principalColumn: "Id");
        }
    }
}
