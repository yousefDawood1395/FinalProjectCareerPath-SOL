using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPath.Migrations
{
    public partial class isertintoAspNetRolesstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @"insert into AspNetRoles(Id,Name,NormalizedName,Description)
                            values(1, 'student', 'STUDENT', 'can take courses and exams')";

            migrationBuilder.Sql(query);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var DelQuery = @"delete from AspNetRoles 
                            where Name='student'";
        }
    }
}
