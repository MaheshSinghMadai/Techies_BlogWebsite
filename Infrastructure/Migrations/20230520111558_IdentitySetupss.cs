using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySetupss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                schema: "Identity",
                table: "Blogposts",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                schema: "Identity",
                table: "Blogposts",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "Identity",
                table: "Blogposts",
                newName: "AuthorName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Identity",
                table: "Blogposts",
                newName: "AuthorId");
        }
    }
}
