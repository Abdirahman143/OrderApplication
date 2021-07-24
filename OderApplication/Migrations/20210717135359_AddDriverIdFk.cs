using Microsoft.EntityFrameworkCore.Migrations;

namespace OderApplication.Migrations
{
    public partial class AddDriverIdFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Ambulances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ambulances_DriverId",
                table: "Ambulances",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambulances_drivers_DriverId",
                table: "Ambulances",
                column: "DriverId",
                principalTable: "drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambulances_drivers_DriverId",
                table: "Ambulances");

            migrationBuilder.DropIndex(
                name: "IX_Ambulances_DriverId",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Ambulances");
        }
    }
}
