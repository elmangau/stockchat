using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mangau.Demos.StockChat.Infrastructure.MySql.Migrations
{
    public partial class ChatMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scchatmessage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostedById = table.Column<long>(nullable: false),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scchatmessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scchatmessage_secuser_PostedById",
                        column: x => x.PostedById,
                        principalTable: "secuser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scchatmessage_PostedById",
                table: "scchatmessage",
                column: "PostedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scchatmessage");
        }
    }
}
