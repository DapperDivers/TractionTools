using Microsoft.EntityFrameworkCore.Migrations;

namespace TractionTools.Data.Migrations
{
    public partial class addUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserOwns",
                table: "RecipeIngredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserOwns",
                table: "RecipeIngredients");
        }
    }
}
