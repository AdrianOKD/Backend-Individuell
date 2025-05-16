using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuell_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifedAt",
                table: "FolderEntity",
                newName: "ModifiedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "FolderEntity",
                newName: "ModifedAt");
        }
    }
}
