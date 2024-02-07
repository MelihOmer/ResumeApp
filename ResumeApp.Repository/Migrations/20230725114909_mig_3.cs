using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Continue",
                table: "Experiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Continue",
                table: "Educations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continue",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Continue",
                table: "Educations");
        }
    }
}
