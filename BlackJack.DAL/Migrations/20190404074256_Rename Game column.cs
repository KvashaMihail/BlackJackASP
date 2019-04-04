using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DAL.Migrations
{
    public partial class RenameGamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Games",
                newName: "DateFinishLastRound");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateFinishLastRound",
                table: "Games",
                newName: "DateEnd");
        }
    }
}
