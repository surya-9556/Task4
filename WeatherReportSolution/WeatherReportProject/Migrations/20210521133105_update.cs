using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherReportProject.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowTemp",
                table: "Weathers");

            migrationBuilder.AlterColumn<int>(
                name: "HighTemp",
                table: "Weathers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HighTemp",
                table: "Weathers",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "LowTemp",
                table: "Weathers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
