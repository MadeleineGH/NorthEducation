using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_API.Data.Migrations
{
    public partial class ChangedCourseProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Course",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
