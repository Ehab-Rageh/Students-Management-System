using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students_Management.Migrations
{
    /// <inheritdoc />
    public partial class updatev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Courses",
            type: "nvarchar(50)",
            nullable: false,
            oldType: "nvarchar(20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Courses",
            type: "nvarchar(20)",
            nullable: false,
            oldType: "nvarchar(50)");
        }
    }
}
