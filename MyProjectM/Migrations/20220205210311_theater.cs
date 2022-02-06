using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectM.Migrations
{
    public partial class theater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<int>(
                name: "theaterId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "theater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theater", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_theaterId",
                table: "Ticket",
                column: "theaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_theater_theaterId",
                table: "Ticket",
                column: "theaterId",
                principalTable: "theater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_theater_theaterId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "theater");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_theaterId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "theaterId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Ticket",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "Ticket",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
