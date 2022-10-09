using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class collectionimageseparate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Collections");

            migrationBuilder.CreateTable(
                name: "CollectionImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", maxLength: 5000000, nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionImage_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionImage_CollectionId",
                table: "CollectionImage",
                column: "CollectionId",
                unique: true,
                filter: "[CollectionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Collections",
                type: "varbinary(max)",
                maxLength: 5000000,
                nullable: true);
        }
    }
}
