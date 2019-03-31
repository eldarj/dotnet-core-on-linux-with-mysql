using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLib.Migrations
{
    public partial class AuthTOkens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    DateGenerated = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    ModeratorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthTokens_Moderators_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Moderators",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_ModeratorId",
                table: "AuthTokens",
                column: "ModeratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthTokens");
        }
    }
}
