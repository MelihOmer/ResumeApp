using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig_IdentityEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "967EAD1D-4F14-4AD6-AB21-05C355E05C72", "a0289be6-93bc-4733-8403-e1a62a9c4c16", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "10037089-DB95-4D47-AEC3-F12A290CC9AB", 0, "e83b973d-d51c-4704-a5cf-166ffb58ef1d", "admin@mail.com", false, "Melih Ömer KAMAR", false, null, "ADMIN@MAIL.COM", "MELIH OMER KAMAR", "AQAAAAIAAYagAAAAEHzfdvsWnMQyFdQQyt7NvUOfs9dRarCQqBhe8lKy5wjK9XNdQnud2CwxSKO3uAXieg==", "123456789", false, "1fced5e8-f1b6-467a-beb9-bb615d3e4ce9", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "967EAD1D-4F14-4AD6-AB21-05C355E05C72", "10037089-DB95-4D47-AEC3-F12A290CC9AB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "967EAD1D-4F14-4AD6-AB21-05C355E05C72", "10037089-DB95-4D47-AEC3-F12A290CC9AB" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967EAD1D-4F14-4AD6-AB21-05C355E05C72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10037089-DB95-4D47-AEC3-F12A290CC9AB");
        }
    }
}
