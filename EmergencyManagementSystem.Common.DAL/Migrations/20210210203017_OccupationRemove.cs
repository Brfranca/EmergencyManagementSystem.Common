using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    public partial class OccupationRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Occupations_OccupationId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Occupations",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OccupationId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Company",
                schema: "dbo",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "Occupation",
                schema: "dbo",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupation",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.AlterColumn<short>(
                name: "Company",
                schema: "dbo",
                table: "Employees",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<short>(
                name: "OccupationId",
                schema: "dbo",
                table: "Employees",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Occupations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profession = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OccupationId",
                schema: "dbo",
                table: "Employees",
                column: "OccupationId");

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
    }
}
