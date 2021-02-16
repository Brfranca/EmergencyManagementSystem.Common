using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    public partial class AddRequester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requesters",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requesters_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requesters_AddressId",
                schema: "dbo",
                table: "Requesters",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requesters",
                schema: "dbo");
        }
    }
}
