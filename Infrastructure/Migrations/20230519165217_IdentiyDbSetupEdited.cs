using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentiyDbSetupEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogposts_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "Blogposts");

            migrationBuilder.DropIndex(
                name: "IX_Blogposts_ApplicationUserId",
                schema: "Identity",
                table: "Blogposts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Blogposts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Blogposts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Blogposts_ApplicationUserId",
                schema: "Identity",
                table: "Blogposts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogposts_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "Blogposts",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
