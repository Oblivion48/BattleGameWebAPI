using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleGameWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerProfile_AccountData_OneToOne_WithBaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountDataId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BaseData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTemplateData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTemplateData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    PlayerProfileId = table.Column<int>(type: "int", nullable: false),
                    BaseDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Profiles_PlayerProfileId",
                        column: x => x.PlayerProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SquadData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCount = table.Column<int>(type: "int", nullable: false),
                    UnitTemplateDataId = table.Column<int>(type: "int", nullable: false),
                    BaseDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadData_BaseData_BaseDataId",
                        column: x => x.BaseDataId,
                        principalTable: "BaseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadData_UnitTemplateData_UnitTemplateDataId",
                        column: x => x.UnitTemplateDataId,
                        principalTable: "UnitTemplateData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BaseDataId",
                table: "Accounts",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PlayerProfileId",
                table: "Accounts",
                column: "PlayerProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SquadData_BaseDataId",
                table: "SquadData",
                column: "BaseDataId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadData_UnitTemplateDataId",
                table: "SquadData",
                column: "UnitTemplateDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SquadData");

            migrationBuilder.DropTable(
                name: "BaseData");

            migrationBuilder.DropTable(
                name: "UnitTemplateData");

            migrationBuilder.DropColumn(
                name: "AccountDataId",
                table: "Profiles");
        }
    }
}
