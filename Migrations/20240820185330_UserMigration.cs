using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Password",
                table: "Users",
                newName: "userPassword");

            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "User_Email",
                table: "Users",
                newName: "userEmail");

            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                table: "Users",
                newName: "phoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "Users",
                newName: "User_Password");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "User_Name");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Users",
                newName: "User_Email");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Users",
                newName: "Phone_Number");
        }
    }
}
