using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternalProj.Migrations
{
    /// <inheritdoc />
    public partial class Added_sizeId_workDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Tax",
                table: "WorkDetails",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Cess",
                table: "WorkDetails",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "WorkDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkDetails_SizeId",
                table: "WorkDetails",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDetails_Albums_SizeId",
                table: "WorkDetails",
                column: "SizeId",
                principalTable: "Albums",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDetails_Albums_SizeId",
                table: "WorkDetails");

            migrationBuilder.DropIndex(
                name: "IX_WorkDetails_SizeId",
                table: "WorkDetails");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "WorkDetails");

            migrationBuilder.AlterColumn<double>(
                name: "Tax",
                table: "WorkDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Cess",
                table: "WorkDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
