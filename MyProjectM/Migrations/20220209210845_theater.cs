using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectM.Migrations
{
    public partial class theater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_theater_theaterId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_theater",
                table: "theater");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "theater");

            migrationBuilder.RenameColumn(
                name: "theaterId",
                table: "Ticket",
                newName: "TheaterID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_theaterId",
                table: "Ticket",
                newName: "IX_Ticket_TheaterID");

            migrationBuilder.AlterColumn<int>(
                name: "TheaterID",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheaterID",
                table: "theater",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_theater",
                table: "theater",
                column: "TheaterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_theater_TheaterID",
                table: "Ticket",
                column: "TheaterID",
                principalTable: "theater",
                principalColumn: "TheaterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_theater_TheaterID",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_theater",
                table: "theater");

            migrationBuilder.DropColumn(
                name: "TheaterID",
                table: "theater");

            migrationBuilder.RenameColumn(
                name: "TheaterID",
                table: "Ticket",
                newName: "theaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TheaterID",
                table: "Ticket",
                newName: "IX_Ticket_theaterId");

            migrationBuilder.AlterColumn<int>(
                name: "theaterId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "theater",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_theater",
                table: "theater",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_theater_theaterId",
                table: "Ticket",
                column: "theaterId",
                principalTable: "theater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
