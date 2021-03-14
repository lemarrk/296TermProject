using Microsoft.EntityFrameworkCore.Migrations;

namespace KL296NTermProject.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Topics_TopicID",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Topics_TopicID",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Links",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Topics_TopicID",
                table: "Links",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicID",
                table: "Posts",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Topics_TopicID",
                table: "Videos",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Topics_TopicID",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Topics_TopicID",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Videos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TopicID",
                table: "Links",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Topics_TopicID",
                table: "Links",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Posts_PostID",
                table: "Messages",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicID",
                table: "Posts",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Topics_TopicID",
                table: "Videos",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
