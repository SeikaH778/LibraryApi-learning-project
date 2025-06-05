using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDataBase.Migrations
{
    /// <inheritdoc />
    public partial class again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksIds",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BooksIds",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
