using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class Added_chilssubhead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildSubHeadId",
                table: "RateMasters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RateMasters_ChildSubHeadId",
                table: "RateMasters",
                column: "ChildSubHeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateMasters_ChildSubHeads_ChildSubHeadId",
                table: "RateMasters",
                column: "ChildSubHeadId",
                principalTable: "ChildSubHeads",
                principalColumn: "ChildSubHeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateMasters_ChildSubHeads_ChildSubHeadId",
                table: "RateMasters");

            migrationBuilder.DropIndex(
                name: "IX_RateMasters_ChildSubHeadId",
                table: "RateMasters");

            migrationBuilder.DropColumn(
                name: "ChildSubHeadId",
                table: "RateMasters");
        }
    }
}
