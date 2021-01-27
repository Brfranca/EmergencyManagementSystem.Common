using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Occupation_OccupationId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation");

            migrationBuilder.RenameTable(
                name: "Occupation",
                newName: "Occupations",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                schema: "dbo",
                table: "Occupations",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupations",
                schema: "dbo",
                table: "Occupations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Occupations_OccupationId",
                schema: "dbo",
                table: "Employees",
                column: "OccupationId",
                principalSchema: "dbo",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Occupations_OccupationId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupations",
                schema: "dbo",
                table: "Occupations");

            migrationBuilder.RenameTable(
                name: "Occupations",
                schema: "dbo",
                newName: "Occupation");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                table: "Occupation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Occupation_OccupationId",
                schema: "dbo",
                table: "Employees",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
