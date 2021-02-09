using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Addresses",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
