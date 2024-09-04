#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SocialPlatformApp.Repos.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Table_Friend_Req : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Channel",
                schema: "SocialPlatformAppSchema",
                table: "ChatMessage",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                schema: "SocialPlatformAppSchema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequest_User_RecipientId",
                        column: x => x.RecipientId,
                        principalSchema: "SocialPlatformAppSchema",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequest_User_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "SocialPlatformAppSchema",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_RecipientId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_SenderId",
                schema: "SocialPlatformAppSchema",
                table: "FriendRequest",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequest",
                schema: "SocialPlatformAppSchema");

            migrationBuilder.DropColumn(
                name: "Channel",
                schema: "SocialPlatformAppSchema",
                table: "ChatMessage");
        }
    }
}
