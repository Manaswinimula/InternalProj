using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class addFixSubHeadForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateMasters_MainHeads_SubHeadId",
                table: "RateMasters");

            migrationBuilder.AddForeignKey(
                name: "FK_RateMasters_SubHeads_SubHeadId",
                table: "RateMasters",
                column: "SubHeadId",
                principalTable: "SubHeads",
                principalColumn: "SubHeadId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateMasters_SubHeads_SubHeadId",
                table: "RateMasters");

            migrationBuilder.AddForeignKey(
                name: "FK_RateMasters_MainHeads_SubHeadId",
                table: "RateMasters",
                column: "SubHeadId",
                principalTable: "MainHeads",
                principalColumn: "MainHeadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
