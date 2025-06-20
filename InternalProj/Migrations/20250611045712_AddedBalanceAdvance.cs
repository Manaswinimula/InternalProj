using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalanceAdvance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDetails_ChildSubHeads_ChildSubheadId",
                table: "WorkDetails");

            migrationBuilder.AddColumn<double>(
                name: "Advance",
                table: "WorkOrders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "WorkOrders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ChildSubheadId",
                table: "WorkDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDetails_ChildSubHeads_ChildSubheadId",
                table: "WorkDetails",
                column: "ChildSubheadId",
                principalTable: "ChildSubHeads",
                principalColumn: "ChildSubHeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDetails_ChildSubHeads_ChildSubheadId",
                table: "WorkDetails");

            migrationBuilder.DropColumn(
                name: "Advance",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<int>(
                name: "ChildSubheadId",
                table: "WorkDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDetails_ChildSubHeads_ChildSubheadId",
                table: "WorkDetails",
                column: "ChildSubheadId",
                principalTable: "ChildSubHeads",
                principalColumn: "ChildSubHeadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
