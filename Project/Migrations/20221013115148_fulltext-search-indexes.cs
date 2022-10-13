using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class fulltextsearchindexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON CollectionItems(Name) KEY INDEX PK_CollectionItems;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON CustomStringFields(Value) KEY INDEX PK_CustomStringFields;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON CustomTextAreaFields(Value) KEY INDEX PK_CustomTextAreaFields;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON AspNetUsers(UserName) KEY INDEX PK_AspNetUsers;",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON CollectionItems;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON CustomStringFields;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON CustomTextAreaFields;",
                suppressTransaction: true);
            migrationBuilder.Sql(
                sql: "DROP FULLTEXT INDEX ON AspNetUsers;",
                suppressTransaction: true);
        }
    }
}
