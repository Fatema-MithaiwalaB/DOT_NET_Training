using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Assignment_1.Migrations
{
    /// <inheritdoc />
    public partial class Env_Based : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
