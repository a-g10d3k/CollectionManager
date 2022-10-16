using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class tagftsindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Tags(Name) KEY INDEX PK_Tags;",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON Tags;",
                suppressTransaction: true);
        }
    }
}
