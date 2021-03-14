using Microsoft.EntityFrameworkCore.Migrations;

namespace KL296NTermProject.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkID",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoID",
                table: "Topics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkID",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "VideoID",
                table: "Topics");
        }
    }
}
