using Microsoft.EntityFrameworkCore.Migrations;

namespace KL296NTermProject.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PostID",
                table: "Messages",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_PostID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Messages");
        }
    }
}
