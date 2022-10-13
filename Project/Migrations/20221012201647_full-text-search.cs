using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class fulltextsearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;",
                suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Collections(Name, Description) KEY INDEX PK_Collections;",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT CATALOG ftCatalog AS DEFAULT;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON Collections;",
                suppressTransaction: true);
        }
    }
}
