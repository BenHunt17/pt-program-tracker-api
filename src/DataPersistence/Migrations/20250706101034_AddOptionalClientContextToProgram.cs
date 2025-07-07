using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PtProgramTrackerApi.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionalClientContextToProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Programs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ClientId",
                table: "Programs",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Clients_ClientId",
                table: "Programs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Clients_ClientId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ClientId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Programs");
        }
    }
}
