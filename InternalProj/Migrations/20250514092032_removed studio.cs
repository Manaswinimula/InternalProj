using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class removedstudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Studio",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "RateMasters",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Studio",
                table: "WorkOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "RateMasters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
