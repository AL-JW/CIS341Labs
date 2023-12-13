using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTrackingApp.Migrations.WorkoutTrackingApp
{
    /// <inheritdoc />
    public partial class Added_IDENTITYID_KEY_TO_LINK_WITH_ACCOUNTS_TABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Accounts",
                newName: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Accounts",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
