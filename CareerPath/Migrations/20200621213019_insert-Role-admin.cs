using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class insertRoleadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @"insert into AspNetRoles(Id,Name,NormalizedName,Description)
                            values(2, 'admin', 'ADMIN', 'can Manage every thing in the website')";

            migrationBuilder.Sql(query);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var DelQuery = @"delete from AspNetRoles 
                            where Name='admin'";

            migrationBuilder.Sql(DelQuery);
        }
    }
}
