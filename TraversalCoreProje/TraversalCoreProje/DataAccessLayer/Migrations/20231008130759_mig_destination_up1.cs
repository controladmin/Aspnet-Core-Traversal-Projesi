using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_destination_up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "GuideID",
                table: "Destinations",
                newName: "GuidID");

            migrationBuilder.AddColumn<int>(
                name: "GuideGuidID",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideGuidID",
                table: "Destinations",
                column: "GuideGuidID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideGuidID",
                table: "Destinations",
                column: "GuideGuidID",
                principalTable: "Guides",
                principalColumn: "GuidID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideGuidID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideGuidID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "GuideGuidID",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "GuidID",
                table: "Destinations",
                newName: "GuideID");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations",
                column: "GuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuidID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
