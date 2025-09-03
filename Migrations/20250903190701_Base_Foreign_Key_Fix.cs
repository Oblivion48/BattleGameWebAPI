using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleGameWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Base_Foreign_Key_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_BaseData_BaseDataId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BaseDataId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BaseDataId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountDataId",
                table: "BaseData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BaseData_AccountDataId",
                table: "BaseData",
                column: "AccountDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseData_Accounts_AccountDataId",
                table: "BaseData",
                column: "AccountDataId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseData_Accounts_AccountDataId",
                table: "BaseData");

            migrationBuilder.DropIndex(
                name: "IX_BaseData_AccountDataId",
                table: "BaseData");

            migrationBuilder.DropColumn(
                name: "AccountDataId",
                table: "BaseData");

            migrationBuilder.AddColumn<int>(
                name: "BaseDataId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BaseDataId",
                table: "Accounts",
                column: "BaseDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_BaseData_BaseDataId",
                table: "Accounts",
                column: "BaseDataId",
                principalTable: "BaseData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
