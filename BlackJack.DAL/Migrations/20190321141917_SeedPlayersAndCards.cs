using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJack.DAL.Migrations
{
    public partial class SeedPlayersAndCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Suit", "Value" },
                values: new object[,]
                {
                    { (byte)1, (byte)0, (byte)0 },
                    { (byte)29, (byte)0, (byte)7 },
                    { (byte)31, (byte)2, (byte)7 },
                    { (byte)32, (byte)3, (byte)7 },
                    { (byte)33, (byte)0, (byte)8 },
                    { (byte)34, (byte)1, (byte)8 },
                    { (byte)35, (byte)2, (byte)8 },
                    { (byte)36, (byte)3, (byte)8 },
                    { (byte)37, (byte)0, (byte)9 },
                    { (byte)38, (byte)1, (byte)9 },
                    { (byte)39, (byte)2, (byte)9 },
                    { (byte)40, (byte)3, (byte)9 },
                    { (byte)41, (byte)0, (byte)10 },
                    { (byte)42, (byte)1, (byte)10 },
                    { (byte)43, (byte)2, (byte)10 },
                    { (byte)44, (byte)3, (byte)10 },
                    { (byte)45, (byte)0, (byte)11 },
                    { (byte)46, (byte)1, (byte)11 },
                    { (byte)47, (byte)2, (byte)11 },
                    { (byte)48, (byte)3, (byte)11 },
                    { (byte)49, (byte)0, (byte)12 },
                    { (byte)50, (byte)1, (byte)12 },
                    { (byte)51, (byte)2, (byte)12 },
                    { (byte)52, (byte)3, (byte)12 },
                    { (byte)28, (byte)3, (byte)6 },
                    { (byte)27, (byte)2, (byte)6 },
                    { (byte)30, (byte)1, (byte)7 },
                    { (byte)25, (byte)0, (byte)6 },
                    { (byte)2, (byte)1, (byte)0 },
                    { (byte)3, (byte)2, (byte)0 },
                    { (byte)4, (byte)3, (byte)0 },
                    { (byte)5, (byte)0, (byte)1 },
                    { (byte)6, (byte)1, (byte)1 },
                    { (byte)7, (byte)2, (byte)1 },
                    { (byte)8, (byte)3, (byte)1 },
                    { (byte)9, (byte)0, (byte)2 },
                    { (byte)26, (byte)1, (byte)6 },
                    { (byte)11, (byte)2, (byte)2 },
                    { (byte)12, (byte)3, (byte)2 },
                    { (byte)13, (byte)0, (byte)3 },
                    { (byte)10, (byte)1, (byte)2 },
                    { (byte)15, (byte)2, (byte)3 },
                    { (byte)16, (byte)3, (byte)3 },
                    { (byte)17, (byte)0, (byte)4 },
                    { (byte)18, (byte)1, (byte)4 },
                    { (byte)19, (byte)2, (byte)4 },
                    { (byte)20, (byte)3, (byte)4 },
                    { (byte)21, (byte)0, (byte)5 },
                    { (byte)22, (byte)1, (byte)5 },
                    { (byte)23, (byte)2, (byte)5 },
                    { (byte)14, (byte)1, (byte)3 },
                    { (byte)24, (byte)3, (byte)5 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "IsBot", "Name" },
                values: new object[,]
                {
                    { 6, true, "Adam" },
                    { 5, true, "William" },
                    { 4, true, "Randolph" },
                    { 7, true, "Olivia" },
                    { 2, true, "Kate" },
                    { 1, true, "Bob" },
                    { 3, true, "Harry" },
                    { 8, true, "Dealer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)16);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)17);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)18);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)19);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)20);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)21);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)22);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)23);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)24);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)25);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)26);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)27);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)28);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)29);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)30);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)31);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)32);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)33);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)34);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)35);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)36);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)37);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)38);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)39);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)40);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)41);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)42);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)43);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)44);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)45);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)46);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)47);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)48);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)49);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)50);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)51);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: (byte)52);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
