using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLib.Migrations
{
    public partial class UsersAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminUserID",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AdminUserID",
                table: "Posts",
                column: "AdminUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Admin_AdminUserID",
                table: "Posts",
                column: "AdminUserID",
                principalTable: "Admin",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Admin_AdminUserID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AdminUserID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AdminUserID",
                table: "Posts");
        }
    }
}
